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
    public class TextFileAward: IAwardDAO
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
                if (cache==null)
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
            items.Add(new ItemInFile(){user = null, award = award});
            using (StreamWriter sw = new StreamWriter(_settingsLogic.GetPath(), false))
            {
               sw.Write(JsonConvert.SerializeObject(items)); 
            }
            return 0;
        }

        public IEnumerable<Award> GetAll()
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

                    if (list==null)
                    {
                        cache = new List<Award>();
                    }
                    else
                    {
                        cache = new List<Award>();
                        var awards = list.Select(item => item.award);
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
