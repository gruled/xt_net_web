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
    public class UserRoleFileDAO : IUserRoleDAO
    {
        public void AddRole(UserRole role)
        {
            List<UserRole> userRoles = new List<UserRole>();
            if (File.Exists(ConfigurationManager.AppSettings["UserRolesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UserRolesPath"], true))
                {
                    userRoles = JsonConvert.DeserializeObject<List<UserRole>>(sr.ReadToEnd());
                }

                int id;
                if (userRoles.Any())
                {
                    id = userRoles[userRoles.Count - 1].Id + 1;
                }
                else
                {
                    id = 1;
                }
                userRoles.Add(new UserRole() { Id = id, Title = role.Title});
            }
            else
            {
                userRoles.Add(new UserRole() { Id = 1, Title = role.Title });
            }
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UserRolesPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(userRoles));
            }
        }

        public void DeleteRoleById(int id)
        {
            List<UserRole> userRoles = new List<UserRole>();
            if (File.Exists(ConfigurationManager.AppSettings["UserRolesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UserRolesPath"], true))
                {
                    userRoles = JsonConvert.DeserializeObject<List<UserRole>>(sr.ReadToEnd());
                }

                userRoles.RemoveAll(item => item.Id == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["WebUsersPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(userRoles));
                }
            }
        }

        public IEnumerable<UserRole> GetAllRoles()
        {
            List<UserRole> userRoles = new List<UserRole>();
            if (File.Exists(ConfigurationManager.AppSettings["UserRolesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UserRolesPath"], true))
                {
                    userRoles = JsonConvert.DeserializeObject<List<UserRole>>(sr.ReadToEnd());
                }
            }

            return userRoles;
        }

        public string GetRoleById(int id)
        {
            List<UserRole> userRoles = new List<UserRole>();
            if (File.Exists(ConfigurationManager.AppSettings["UserRolesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UserRolesPath"], true))
                {
                    userRoles = JsonConvert.DeserializeObject<List<UserRole>>(sr.ReadToEnd());
                }
            }

            return userRoles.FirstOrDefault(item => item.Id == id).Title;
        }

        public void UpdateRoleById(int id, UserRole role)
        {
            List<UserRole> userRoles = new List<UserRole>();
            if (File.Exists(ConfigurationManager.AppSettings["UserRolesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UserRolesPath"], true))
                {
                    userRoles = JsonConvert.DeserializeObject<List<UserRole>>(sr.ReadToEnd());
                }

                int count = userRoles.FindIndex(item => item.Id == id);
                int prevId = userRoles[count].Id;
                userRoles[count] = new UserRole()
                {
                    Id = prevId,
                    Title = role.Title
                };
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UserRolesPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(userRoles));
                }
            }
        }
    }
}
