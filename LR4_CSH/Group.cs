using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LR7_CSH
{
    class Group
    {
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Person> People { get; set; } = new List<Person>();
        public static List<Subject> Subjects { get; set; } = new List<Subject>();
        public static decimal Groupnumber { get; set; }

        public static void CreateNewGroup(DataGridViewRowCollection rows, decimal number)
        {
            Groupnumber = number;
            Students.AddRange(rows.Cast<DataGridViewRow>().Select(
                x => new Student()
                {
                    Id = x.Cells[0].Value?.ToString(),
                    Name = x.Cells[2].Value?.ToString(),
                    LastName = x.Cells[1].Value?.ToString(),
                    Groupnumber = number,
                    Subjects = Subjects.ConvertAll(y => y.DeepCopy()),
                }).ToList());
            Students.RemoveAll(x => x.LastName == "" || x.Name == "");
        }
        public static void CreateNewSubjectsList(DataGridViewRowCollection rows)
        {
            Subjects.AddRange(rows.Cast<DataGridViewRow>().Select(
                           x => new Subject() { Caption = x.Cells[0].Value?.ToString() }).ToList());
            Subjects.Remove(Subjects.Where(x => x.Caption == "").First());
        }
        public static void EditSubjectList(DataGridViewRowCollection rows)
        {
            List<Subject> newsubjects = rows.Cast<DataGridViewRow>().Select(
                           x => new Subject() { Caption = x.Cells[0].Value?.ToString() }).ToList();
            newsubjects.RemoveAll(x => x.Caption == "");
            foreach (var stud in Students)
            {
                foreach (var sub in newsubjects)
                {
                    if (!stud.Subjects.Any(x => x.Caption == sub.Caption))
                        stud.Subjects.Add(sub.DeepCopy());
                }
            }
        }
        public static void EditStudentList()
        {
            Students.RemoveAll(x => string.IsNullOrWhiteSpace(x.LastName) || string.IsNullOrWhiteSpace(x.Name));
            AddAnSubjectListForNewStudent();
        }
        private static void AddAnSubjectListForNewStudent()
        {
            foreach (var stud in Students.Where(x => x.Subjects == null))
            {
                stud.Subjects = Subjects.ConvertAll(y => y.DeepCopy());
            }
        }
        public static void ToSubjectsFromFile()
        {
            Groupnumber = Students[0].Groupnumber;
            if (Students.Count > 1)
            {
                FindCommonSubjectsFromStudents(out List<string> sub);
                foreach (var subj in sub)
                {
                    Subjects.Add(new Subject() { Caption = subj });
                }
            }
            else
            {
                Subjects = Students[0].Subjects;
            }
        }
        private static void FindCommonSubjectsFromStudents(out List<string> sub)
        {
            sub = new List<string>();
            for (int i = 0; i < Students.Count; i++)
            {
                if (i == 0)
                {
                    sub.AddRange(Students[i].Subjects.Select(x => x.Caption).ToList()
                    .Intersect(Students[i + 1].Subjects.Select(x => x.Caption).ToList()).ToList());
                    i++;
                }
                else
                {
                    sub = sub.Intersect(Students[i].Subjects.Select(x => x.Caption).ToList()).ToList();
                }
            }
        }
    }
}
