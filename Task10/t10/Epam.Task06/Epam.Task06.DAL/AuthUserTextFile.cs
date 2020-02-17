using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.BLL.Interfaces;
using Epam.Task06.DAL.Interfaces;
using Epam.Task06.Entities;
using Newtonsoft.Json;

namespace Epam.Task06.DAL
{
    public class AuthUserTextFile : IAuthUser
    {
        private List<AuthUser> items = null;
        private ISettingsLogic _settingsLogic;

        public AuthUserTextFile(ISettingsLogic settingsLogic)
        {
            _settingsLogic = settingsLogic;
        }
        public int Add(Entities.AuthUser authUser)
        {
            if (File.Exists(_settingsLogic.GetPathToUsers()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPathToUsers(), true))
                {
                    items = JsonConvert.DeserializeObject<List<AuthUser>>(sr.ReadToEnd());
                }
                items.Add(authUser);
                using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPathToUsers(), false))
                {
                    sw.Write(JsonConvert.SerializeObject(items));
                }
                return 0;
            }
            else
            {
                items = new List<AuthUser>();
                items.Add(authUser);
                using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPathToUsers(), false))
                {
                    sw.Write(JsonConvert.SerializeObject(items));
                }
                return 0;
            }

 
        }

        public int ChangeAdmin(string name)
        {
            if (File.Exists(_settingsLogic.GetPathToUsers()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPathToUsers(), true))
                {
                    items = JsonConvert.DeserializeObject<List<AuthUser>>(sr.ReadToEnd());
                }

                var users = items.Where(item => item.Name.Equals(name));
                foreach (var item in users)
                {
                    item.IsAdmin = !item.IsAdmin;
                }
                using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPathToUsers(), false))
                {
                    sw.Write(JsonConvert.SerializeObject(items));
                }
                return 0;
            }

            return 1;
        }

        public IEnumerable<Entities.AuthUser> GetAllAuthUsers()
        {
            using (StreamReader sr = new StreamReader(_settingsLogic.GetPathToUsers(), true))
            {
                items = JsonConvert.DeserializeObject<List<AuthUser>>(sr.ReadToEnd());
            }

            return items;
        }
    }
}
