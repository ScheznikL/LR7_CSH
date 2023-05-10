using System;
using System.Collections.Generic;

namespace LR7_CSH
{
    class Student : Person
    {
        private uint _id;
        private List<Subject> _subjects;
        public string Id
        {
            get => _id.ToString();
            set => _id = Convert.ToUInt32(value);
        }
        public uint GetIdForDB() => _id;
        public decimal Groupnumber { get; set; }
        public List<Subject> Subjects
        {
            get => _subjects;
            set
            {
                if(value.Count <= 35) _subjects = value;
            }
        }

        public Student() : base() { }
        public Student(string name, string lastName, uint group, List<Subject> subjects) : base(name, lastName)
        {
            Groupnumber = group;
            Subjects = subjects;
        }
    }
}
