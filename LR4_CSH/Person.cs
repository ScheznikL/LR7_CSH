using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_CSH
{
    class Person
    {
        private string _name;
        private string _lastName;
        public string Name
        {
            get => _name;
            set
            {
                if (value != null) _name = ValidateUserString.CapitalizeFirstLetter(value);
            }
        }
        public string LastName
        {
            get => _lastName; set
            {
                if (value != null) _lastName = ValidateUserString.CapitalizeFirstLetter(value);
            }
        }
        public Person()
        {
            _name = "";
            _lastName = "";
        }
        public Person(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}
