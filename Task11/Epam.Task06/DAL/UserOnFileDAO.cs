using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Newtonsoft.Json;

namespace DAL
{
    public class UserOnFileDAO : IUserDAO
    {
        
        public int Add(User user)
        {
            int id=1;
            List<User> users = new List<User>();
            if (File.Exists(ConfigurationManager.AppSettings["UsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersPath"], true))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }

                if (users.Any())
                { 
                    id = users[users.Count-1].Id + 1;
                }
                else
                {
                    id = 1;
                }
                users.Add(new User() { Id = id, Name = user.Name, Age = user.Age, DateOfBirth = user.DateOfBirth });
            }
            else
            {
                users.Add(new User() { Id = 1, Name = user.Name, Age = user.Age, DateOfBirth = user.DateOfBirth });
            }

            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }

            return id;
        }

        public void DeleteById(int id)
        {
            List<User> users;
            if (File.Exists(ConfigurationManager.AppSettings["UsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersPath"], true))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }

                users.RemoveAll(item => item.Id == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(users));
                }
            }
            
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            if (File.Exists(ConfigurationManager.AppSettings["UsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersPath"], true))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }
            }

            return users;
        }

        public User GetUserById(int id)
        {
            List<User> users = new List<User>();
            if (File.Exists(ConfigurationManager.AppSettings["UsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersPath"], true))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }
            }

            return users.FirstOrDefault(item => item.Id == id);
        }

        public void Update(int id, User newUser)
        {
            List<User> users;
            if (File.Exists(ConfigurationManager.AppSettings["UsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersPath"], true))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }

                int count = users.FindIndex(item => item.Id == id);
                int prevId = users[count].Id;
                users[count] = new User()
                {
                    Id = prevId,
                    Name = newUser.Name,
                    Age = newUser.Age,
                    DateOfBirth = newUser.DateOfBirth
                };

                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(users));
                }
            }
        }
    }
}
