using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee : User
    {
        private float _experience;
        private string _position;

        public string Position
        {
            get => _position;
            set => _position = value;
        }


        public float Experience
        {
            get { return _experience; }
            set
            {
                if (value >= 0.0f)
                {
                    _experience = value;
                }
                else
                {
                    _experience = 0.0f;
                }
            }
        }

        public Employee(string name, string lastName, string surname, DateTime dateBirth, float experience, string position) : base(name, lastName, surname, dateBirth)
        {
            base.Name = name;
            base.LastName = lastName;
            base.Surname = surname;
            base.DateBirth = dateBirth;
            this.Experience = experience;
            this._position = position;
        }
    }
}
