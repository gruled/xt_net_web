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
        public List<ItemInFile> items = new List<ItemInFile>();
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
                    items = JsonConvert.DeserializeObject<List<ItemInFile>>(sr.ReadToEnd());
                    if (cache == null)
                    {
                        cache = new List<User>();
                        var users = items.Select(item => item.user);
                        foreach (var item in users)
                        {
                            cache.Add(item);
                        }
                    }
                }
            }
            else
            {
                cache = new List<User>();
            }
            cache.Add(user);
            items.Add(new ItemInFile(){user = user, award = null});
            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
                sw.Write(JsonConvert.SerializeObject(items));
            }

            return 0;
        }

        public void DeleteById(int id)
        {

            List<ItemInFile> items = new List<ItemInFile>();
            using (StreamReader sr = new StreamReader(_settingsLogic.GetPath()))
            {
                string value = sr.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ItemInFile>>(value);
            }

            if (items == null)
            {
                cache = new List<User>();
            }
            else
            {
                cache = new List<User>();
                items.RemoveAll(item => item.user?.Id == id);
                var users = items.Select(item => item.user);
                foreach (var item in users)
                {
                    cache.Add(item);
                }
            }

            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
                sw.Write(JsonConvert.SerializeObject(items));
            }

        }

        public IEnumerable<User> GetAll()
        {
            if (cache.Any())
            {
                return cache;
            }
            else
            {
                List<ItemInFile> list = new List<ItemInFile>();
                if (File.Exists(_settingsLogic.GetPath()))
                {
                    using (StreamReader sr = new StreamReader(_settingsLogic.GetPath(), true))
                    {
                        list = JsonConvert.DeserializeObject<List<ItemInFile>>(sr.ReadToEnd());
                    }

                    if (list == null)
                    {
                        cache = new List<User>();
                    }
                    else
                    {
                        cache = new List<User>();
                        var awards = list.Select(item => item.user);
                        foreach (var item in awards)
                        {
                            if (item!=null)
                            {
                                cache.Add(item);
                            }
                        }
                    }
                }
                return cache;
            }
        }
    }
}
