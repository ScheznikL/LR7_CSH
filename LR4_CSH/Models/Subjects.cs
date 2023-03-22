using System;

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
                if (value != null) _caption = ValidateUserString.CapitalizeFirstLetter(value);
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
        public Subject DeepCopy()
        {
            Subject other = (Subject)this.MemberwiseClone();
            other.Caption = string.Copy(Caption);
            return other;
        }
    }
}
