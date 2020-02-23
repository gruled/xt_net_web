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
    public class WebUserFileDao : IWebUserDAO
    {
        public void AddWebUser(WebUser user)
        {
           List<WebUser> webUsers = new List<WebUser>();
           if (File.Exists(ConfigurationManager.AppSettings["WebUsersPath"]))
           {
               using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["WebUsersPath"], true))
               {
                   webUsers = JsonConvert.DeserializeObject<List<WebUser>>(sr.ReadToEnd());
               }

               int id;
               if (webUsers.Any())
               {
                   id = webUsers[webUsers.Count - 1].Id + 1;
               }
               else
               {
                   id = 1;
               }
               webUsers.Add(new WebUser(){Id = id, Login = user.Login, Password = user.Password, Role = user.Role});
           }
           else
           {
               webUsers.Add(new WebUser() { Id = 1, Login = user.Login, Password = user.Password, Role = user.Role });
           }
           using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["WebUsersPath"], false))
           {
               sw.Write(JsonConvert.SerializeObject(webUsers));
           }
        }

        public void DeleteWebUserById(int id)
        {
            List<WebUser> webUsers;
            if (File.Exists(ConfigurationManager.AppSettings["WebUsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["WebUsersPath"], true))
                {
                    webUsers = JsonConvert.DeserializeObject<List<WebUser>>(sr.ReadToEnd());
                }

                webUsers.RemoveAll(item => item.Id == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["WebUsersPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(webUsers));
                }
            }
        }

        public IEnumerable<WebUser> GetAllWebUsers()
        {
            List<WebUser> webUsers = new List<WebUser>();
            if (File.Exists(ConfigurationManager.AppSettings["WebUsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["WebUsersPath"], true))
                {
                    webUsers = JsonConvert.DeserializeObject<List<WebUser>>(sr.ReadToEnd());
                }
            }

            return webUsers;
        }

        public int GetRoleById(int id)
        {
            List<WebUser> webUsers = new List<WebUser>();
            if (File.Exists(ConfigurationManager.AppSettings["WebUsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["WebUsersPath"], true))
                {
                    webUsers = JsonConvert.DeserializeObject<List<WebUser>>(sr.ReadToEnd());
                }
            }

            WebUser user = webUsers.FirstOrDefault(item => item.Id == id);
            return user.Role;
        }

        public WebUser GetWebUserById(int id)
        {
            List<WebUser> webUsers = new List<WebUser>();
            if (File.Exists(ConfigurationManager.AppSettings["WebUsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["WebUsersPath"], true))
                {
                    webUsers = JsonConvert.DeserializeObject<List<WebUser>>(sr.ReadToEnd());
                }
            }

            return webUsers.FirstOrDefault(item => item.Id == id);
        }

        public void UpdateWebUserById(int id, WebUser webUser)
        {
            List<WebUser> webUsers;
            if (File.Exists(ConfigurationManager.AppSettings["WebUsersPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["WebUsersPath"], true))
                {
                    webUsers = JsonConvert.DeserializeObject<List<WebUser>>(sr.ReadToEnd());
                }

                int count = webUsers.FindIndex(item => item.Id == id);
                int prevId = webUsers[count].Id;
                webUsers[count] = new WebUser()
                {
                    Id = prevId,
                    Login = webUser.Login,
                    Password = webUser.Password,
                    Role = webUser.Role
                };
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["WebUsersPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(webUsers));
                }
            }
        }
    }
}
