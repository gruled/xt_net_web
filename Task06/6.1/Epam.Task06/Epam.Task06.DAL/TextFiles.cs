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
    public class TextFiles : IUserDAO
    {
        private List<User> cache = null;
        private ISettingsLogic _settingsLogic;

        public TextFiles(ISettingsLogic settingslogic)
        {
            cache = new List<User>();
            _settingsLogic = settingslogic;
        }

        public int Add(User user)
        {
            if (File.Exists(_settingsLogic.GetPath()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPath(), true))
                {
                    cache = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                    if (cache == null)
                    {
                        cache = new List<User>();
                    }
                }
            }
            else
            {
                cache = new List<User>();
            }
            cache.Add(user);
            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
                sw.Write(JsonConvert.SerializeObject(cache));
            }

            return 0;
        }

        public void DeleteById(int id)
        {
            if (cache.Any())
            {
                cache.RemoveAll(item => item.Id == id);
                using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
                {
                    sw.Write(JsonConvert.SerializeObject(cache));
                }
            }
            else
            {
                List<User> list = new List<User>();
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPath()))
                {
                    string value = sr.ReadToEnd();
                    list = JsonConvert.DeserializeObject<List<User>>(value);
                }

                if (list == null)
                {
                    cache = new List<User>();
                }
                else
                {
                    list.RemoveAll(item => item.Id == id);
                    cache = list;
                }

                using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
                {
                    sw.Write(JsonConvert.SerializeObject(cache));
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            if (!cache.Any())
            {
                List<User> list = new List<User>();
                if (File.Exists(_settingsLogic.GetPath()))
                {
                    using (StreamReader sr = new StreamReader(_settingsLogic.GetPath()))
                    {
                        string value = sr.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<User>>(value);
                    }
                }

                if (list == null)
                {
                    cache = new List<User>();
                }
                else
                {
                    cache = list.FindAll(item => item != null);
                }
                return cache;
            }
            else
            {
                return cache;
            }
        }
    }
}
