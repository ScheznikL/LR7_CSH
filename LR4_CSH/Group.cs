using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_CSH
{
    class Group
    {
        public Group(Student student)
        {
            //_students.Add(student);
        }
        public Group() { }
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Person> People { get; set; } = new List<Person>();
        public static List<Subject> Subjects { get; set; } = new List<Subject>();
        ///Equality comp
        public static decimal Groupnumber { get; set; }
        //internal static List<Subject> Subjects
        //{
        //    get => _subjects = new List<Subject>();
        //    set
        //    { _subjects = value;
        //       // subjChanged.?Invoke();
        //    }
        //}
        public static void CreateNewGroup(DataGridViewRowCollection rows, decimal number)
        {
            Groupnumber = number;
            //People.AddRange(rows.Cast<DataGridViewRow>().Select(
            //    x => new Person()
            //    {                    
            //        Name = x.Cells[1].Value?.ToString(),
            //        LastName = x.Cells[2].Value?.ToString(),
            //        Groupnumber = number
            //    }).ToList());
            Students.AddRange(rows.Cast<DataGridViewRow>().Select(
                x => new Student()
                {
                    Id = x.Cells[0].Value?.ToString(),
                    Name = x.Cells[2].Value?.ToString(),
                    LastName = x.Cells[1].Value?.ToString(),
                    Groupnumber = number,
                    Subjects = Subjects.ConvertAll(y => y.DeepCopy()) /*new List<Subject>(Subjects)*/, //What is this?
                }).ToList());
            Students.RemoveAll(x => x.LastName == "" && x.Name == "");
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
            //List<Student> newstudlist = rows.Cast<DataGridViewRow>().Select(
            //    x => new Student()
            //    {
            //        Id = x.Cells[0].Value?.ToString(),
            //        Name = x.Cells[1].Value?.ToString(),
            //        LastName = x.Cells[2].Value?.ToString(),
            //        Groupnumber = Groupnumber,
            //        Subjects = Subjects.ConvertAll(y => y.DeepCopy())
            //    }).ToList();
            Students.RemoveAll(x => x.LastName == "" && x.Name == "");
            AddAnSubjectListForNewStudent();
        }
        private static void AddAnSubjectListForNewStudent()
        {
            foreach (var stud in Students.Where(x => x.Subjects == null))
            {
                stud.Subjects = Subjects.ConvertAll(y => y.DeepCopy());
            }
        }
        public static void ToSubjectsFromDeser()
        {
            List<string> sub;
            FindCommonSubjectsFromStudents(out sub);
            foreach(var subj in sub)
            {
                Subjects.Add(new Subject() { Caption = subj });
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
