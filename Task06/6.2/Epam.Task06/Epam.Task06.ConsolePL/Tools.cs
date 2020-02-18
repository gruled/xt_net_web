using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DR = Epam.Task06.DependencyResolver.DependencyResolver;

namespace Epam.Task06.ConsolePL
{
    class Tools
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine($"{Environment.NewLine}1:  add user{Environment.NewLine}" +
                                  $"2:  delete user by id{Environment.NewLine}" +
                                  $"3:  update user by id{Environment.NewLine}" +
                                  $"4:  view all users and his awards{Environment.NewLine}" +
                                  $"5:  add award{Environment.NewLine}" +
                                  $"6:  delete award by id{Environment.NewLine}" +
                                  $"7:  update award by id{Environment.NewLine}" +
                                  $"8:  view all awards{Environment.NewLine}" +
                                  $"9:  get award to user{Environment.NewLine}" +
                                  $"10: delete link{Environment.NewLine}" +
                                  $"0:  exit");
                int choise = EnterInt("option", 0, 10);
                switch (choise)
                {
                    case 0: return;
                    case 1:DR.UserLogic.Add(CreateUser()); 
                        break;
                    case 2:DR.UserLogic.DeleteById(GetUserId());
                        break;
                    case 3:DR.UserLogic.Update(GetUserId(),CreateUser());
                        break;
                    case 4:ShowUsersAndHisAwards();
                        break;
                    case 5:DR.AwardLogic.Add(CreateAward());
                        break;
                    case 6:DR.AwardLogic.DeleteById(GetAwardId());
                        break;
                    case 7:DR.AwardLogic.Update(GetAwardId(), CreateAward());
                        break;
                    case 8:ShowAllAwards();
                        break;
                    case 9:DR.UsersAndAwardsLogic.AddLink(GetUserId(), GetAwardId());
                        break;
                    case 10:DR.UsersAndAwardsLogic.DeleteLink(GetUserId(), GetAwardId());
                        break;
                }
            }
        }

        private int EnterInt(string name, int min, int max)
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
                    else
                    {
                        Console.WriteLine($"Entered number not in range");
                    }
                }
                else
                {
                    Console.WriteLine($"Entered symbols not cast to number");
                }
            }
        }

        private Award CreateAward()
        {
            string title = EnterText("title");
            Award award  = new Award()
            {
                Title = title
            };
            return award;
        }

        private string EnterText(string name)
        {
            Console.Write($"Enter {name}:");
            return Console.ReadLine();
        }

        private User CreateUser()
        {
            string name;
            int age;
            DateTime birthDate;
            Console.Write($"Enter name: ");
            name = Console.ReadLine();
            Console.Write($"Enter birthdate (dd-mm-yyyy): ");
            birthDate = enterDateTime();
            age = EnterInt("age", 0, int.MaxValue);
            User user = new User()
            {
                Name = name,
                Age = age,
                DateOfBirth = birthDate
            };
            return user;
        }
        private DateTime enterDateTime()
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

        private void ShowUsersAndHisAwards()
        {
            foreach (var item in DR.UserLogic.GetAll())
            {
                Console.WriteLine($"NAME:{item.Name}  AGE:{item.Age}   Date:{item.DateOfBirth}");
                Console.WriteLine($"Awards:");
                foreach (var tmp in DR.UsersAndAwardsLogic.GetAll().Where(tmp => tmp.IdUser == item.Id))
                {
                    Console.WriteLine($"   {DR.AwardDAO.GetAwardById(tmp.IdAward).Title}");
                }
            }
        }

        private void ShowAllAwards()
        {
            Console.WriteLine($"Awards:");
            foreach (var item in DR.AwardLogic.GetAll())
            {
                Console.WriteLine($"   {item.Title}");
            }
        }

        private int GetUserId()
        {
            int id = default;
            List<User> list = new List<User>();
            var items = DR.UserLogic.GetAll();
            foreach (var item in items)
            {
                list.Add(item);
            }

            Console.WriteLine($"Users Id's");
            while (true)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"   {item.Id}");
                }

                id = EnterInt("user id", 0, Int32.MaxValue);
                if (list.Any(item => item.Id == id))
                {
                    return id;
                }
                else
                {
                    Console.WriteLine($"Entered id not exist in users");
                }
            }
        }

        private int GetAwardId()
        {
            int id = default;
            List<Award> list = new List<Award>();
            var items = DR.AwardLogic.GetAll();
            foreach (var item in items)
            {
                list.Add(item);
            }

            Console.WriteLine($"Awards Id's");
            while (true)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"   {item.Id}");
                }

                id = EnterInt("award id", 0, Int32.MaxValue);
                if (list.Any(item => item.Id == id))
                {
                    return id;
                }
                else
                {
                    Console.WriteLine($"Entered id not exist in users");
                }
            }
        }
    }
}
