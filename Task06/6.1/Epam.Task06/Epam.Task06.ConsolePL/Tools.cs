using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.Entities;



namespace Epam.Task06.ConsolePL
{
    class Tools
    {
        public static void ReadFilePath()
        {
            if (ConfigurationManager.AppSettings["DAL"].Equals("TextFile"))
            {
                Console.Write($"Input file: ");
                string value = Console.ReadLine();
                DependencyResolver.DependencyResolver.SettingsLogic.SetPath(value);
            }
        }

        public static void WorkWithFile()
        {
            while (true)
            {
                Console.WriteLine($"1- add user{Environment.NewLine}2- delete by id{Environment.NewLine}3- view users{Environment.NewLine}0-exit");
                int choise = EnterInt("option", 0, 3);
                switch (choise)
                {
                    case 0: return;
                    case 1:
                        DependencyResolver.DependencyResolver.UserLogic.Add(createUser());
                        break;
                    case 2:
                        DependencyResolver.DependencyResolver.UserLogic.DeleteById(EnterInt("id", int.MinValue, int.MaxValue));
                        break;
                    case 3:
                        foreach (var item in DependencyResolver.DependencyResolver.UserLogic.GetAll())
                        {
                            Console.WriteLine($"Id= {item.Id}\tName= {item.Name}\tBirthDate= {item.DateOfBirth}\tAge= {item.Age}");
                        }
                        break;
                }
            }
        }
        static int EnterInt(string name, int min, int max)
        {
            while (true)
            {
                Console.Write($"Input {name}: ");
                string value = Console.ReadLine();
                int i = default;
                if (int.TryParse(value, out i))
                {
                    if (i >= min && i <= max)
                    {
                        return i;
                    }
                }
            }
        }

        static User createUser()
        {
            int id;
            string name;
            DateTime birthDate;
            int age;
            id = EnterInt("id", int.MinValue, int.MaxValue);
            Console.Write($"Enter name: ");
            name = Console.ReadLine();
            Console.Write($"Enter birthdate (dd-mm-yyyy): ");
            birthDate = enterDateTime();
            age = EnterInt("age", 0, int.MaxValue);
            User user = new User()
            {
                Id = id,
                Name = name,
                Age = age,
                DateOfBirth = birthDate
            };
            return user;
        }

        static DateTime enterDateTime()
        {
            while (true)
            {
                string value;
                value = Console.ReadLine();
                DateTime res;
                if (DateTime.TryParse(value, out res))
                {
                    return res;
                }
            }
        }
    }
}
