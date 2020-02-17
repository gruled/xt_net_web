using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
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
                Console.WriteLine($"1- add user{Environment.NewLine}2- delete user by id{Environment.NewLine}3- view users{Environment.NewLine}4- add award{Environment.NewLine}5- view awards{Environment.NewLine}0-exit");
                int choise = EnterInt("option", 0, 5);
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
                        List<Award> awardsTotal = (List<Award>) DependencyResolver.DependencyResolver.AwardLogic.GetAll();
                        foreach (var item in DependencyResolver.DependencyResolver.UserLogic.GetAll())
                        {
                            if (item!=null)
                            {
                                Console.WriteLine($"Id= {item.Id}\tName= {item.Name}\tBirthDate= {item.DateOfBirth}\tAge= {item.Age}");
                                Console.WriteLine($"Awards:");
                                List<int> currentAWards = item.Awards;
                                foreach (var items in currentAWards)
                                {
                                    Console.WriteLine($"{awardsTotal.FirstOrDefault(x => x.Id == items).Title}");
                                }
                            }
                        }
                        break;
                    case 4:
                        DependencyResolver.DependencyResolver.AwardLogic.Add(createAward());
                        break;
                    case 5:
                        List<Award> awards =(List<Award>) DependencyResolver.DependencyResolver.AwardLogic.GetAll();
                        Console.WriteLine("Awards:");
                        foreach (var item in awards)
                        {
                            Console.WriteLine($"Id= {item.Id}\tTitle= {item.Title}");
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

                Console.WriteLine("not");
            }
        }

        static User createUser()
        {
            int id;
            string name;
            DateTime birthDate;
            int age;
            List<int> awards;
            id = EnterInt("id", int.MinValue, int.MaxValue);
            Console.Write($"Enter name: ");
            name = Console.ReadLine();
            Console.Write($"Enter birthdate (dd-mm-yyyy): ");
            birthDate = enterDateTime();
            age = EnterInt("age", 0, int.MaxValue);
            awards = fillAwards();
            User user = new User()
            {
                Id = id,
                Name = name,
                Age = age,
                DateOfBirth = birthDate,
                Awards = awards
            };
            return user;
        }

        static List<int> fillAwards()
        {
            List<int> list = new List<int>();
            Console.WriteLine($"Input id for add awards, or \'0\' for exit:");
            int i;
            while (true)
            {
                i = EnterInt("option", int.MinValue, int.MaxValue);
                if (i == 0)
                {
                    break;
                }
                else
                {
                    list.Add(i);
                }
            }

            return list;
        }

        static Award createAward()
        {
            int id;
            string title;
            id = EnterInt("id", int.MinValue, int.MaxValue);
            Console.Write($"Enter title: ");
            title = Console.ReadLine();
            Award award = new Award()
            {
                Id = id,
                Title = title
            };
            return award;
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
