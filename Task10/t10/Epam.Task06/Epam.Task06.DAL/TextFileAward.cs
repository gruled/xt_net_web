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
    public class TextFileAward : IAwardDAO
    {
        private List<Award> cache = null;
        public List<ItemInFile> items = new List<ItemInFile>();
        private ISettingsLogic _settingsLogic;

        public TextFileAward(ISettingsLogic settingsLogic)
        {
            cache = new List<Award>();
            _settingsLogic = settingsLogic;
        }

        public int Add(Award award)
        {
            if (File.Exists(_settingsLogic.GetPath()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPath(), true))
                {
                    items = JsonConvert.DeserializeObject<List<ItemInFile>>(sr.ReadToEnd());
                }

                if (cache == null)
                {
                    if (items.Any())
                    {
                        cache = new List<Award>();
                        var awards = items.Select(item => item.award);
                        foreach (var item in awards)
                        {
                            cache.Add(item);
                        }
                    }
                }
            }
            else
            {
                cache = new List<Award>();
            }

            cache.Add(award);
            items.Add(new ItemInFile() {user = null, award = award});
            int count = 0;
            foreach (var item in items)
            {
                if (item.award != null)
                {
                    item.award.Id = count;
                    count++;
                }
            }

            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
                sw.Write(JsonConvert.SerializeObject(items));
            }

            return 0;
        }

        public IEnumerable<Award> GetAll()
        {

            List<ItemInFile> list = new List<ItemInFile>();
            if (File.Exists(_settingsLogic.GetPath()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPath(), true))
                {
                    list = JsonConvert.DeserializeObject<List<ItemInFile>>(sr.ReadToEnd());
                }

                cache = new List<Award>();
                foreach (var item in list)
                {
                    if (item.award != null)
                    {
                        cache.Add(item.award);
                    }
                }

            }

            return cache;

        }

        public void DeleteById(int id)
        {
            List<ItemInFile> list = new List<ItemInFile>();
            List<ItemInFile> myList = new List<ItemInFile>();
            if (File.Exists(_settingsLogic.GetPath()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPath(), true))
                {
                    list = JsonConvert.DeserializeObject<List<ItemInFile>>(sr.ReadToEnd());
                }

                if (list == null)
                {
                    cache = new List<Award>();
                }
                else
                {
                    cache = new List<Award>();
                    foreach (var item in list)
                    {
                        ItemInFile v = item;
                        if (v.user == null)
                        {
                            if (v.award.Id != id)
                            {
                                myList.Add(v);
                            }
                        }
                        else
                        {
                            if (v.user.Awards.Contains(id))
                            {
                                List<int> li = v.user.Awards;
                                li.Remove(id);
                                v.user.Awards = li;
                                //myList.Add(v);
                            }

                            myList.Add(v);
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
                sw.Write(JsonConvert.SerializeObject(myList));
            }
        }

        public void Update(int id, string newTitle)
        {
            List<ItemInFile> list = new List<ItemInFile>();
            if (File.Exists(_settingsLogic.GetPath()))
            {
                using (StreamReader sr = new StreamReader(_settingsLogic.GetPath(), true))
                {
                    list = JsonConvert.DeserializeObject<List<ItemInFile>>(sr.ReadToEnd());
                }

                foreach (var item in list)
                {
                    if (item.award!=null&&item.award.Id==id)
                    {
                        item.award.Title = newTitle;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
                sw.Write(JsonConvert.SerializeObject(list));
            }

            cache = null;
        }
    }
}
