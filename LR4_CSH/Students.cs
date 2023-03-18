using System;
using System.Collections.Generic;

namespace LR4_CSH
{
    class Student : Person
    {
        public string Id { get; set; }
        public decimal Groupnumber { get; set; }
        public List<Subject> Subjects { get; set; }

        public Student() : base() { }
        public Student(string name, string lastName, string surname, uint group, List<Subject> subjects) : base(name, lastName)
        {
            Groupnumber = group;
            Subjects = subjects;
        }
    }
}
