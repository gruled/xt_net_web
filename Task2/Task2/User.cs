using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class User
    {
        public string Name;
        public string LastName;
        public string Surname;
        public DateTime DateBirth;
        public int Age
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - DateBirth;
                return timeSpan.Days / 365;
            }
        }

        public User(string name, string lastName, string surname, DateTime dateBirth)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Surname = surname;
            this.DateBirth = dateBirth;
        }
    }
}
