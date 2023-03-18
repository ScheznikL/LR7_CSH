using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_CSH
{
    class Subject 
    {
        private uint _grade;
        private string _caption;
        
        public string Caption
        {
            get => _caption;
            set
            {
                if (value != null) _caption = value;
            }
        }
        public uint Grade { get => _grade; set { if (value != 0) { _grade = value; } } }
        public Subject(string caption, uint grade)
        {
            _caption = caption;
            _grade = grade;
        }
        public Subject()
        {
            _caption = "";
            _grade = 0;
        }
        public Subject DeepCopy() //TODO review
        {
            Subject other = (Subject)this.MemberwiseClone();
            other.Caption = string.Copy(Caption);
           // other.Grade = uint.Copy(Grade);//???
            return other;
        }
    }
}
