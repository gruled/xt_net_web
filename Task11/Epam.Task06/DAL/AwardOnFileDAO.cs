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
    public class AwardOnFileDAO : IAwardDAO
    {
        public int Add(Award award)
        {
            int id=1;
            List<Award> awards = new List<Award>();
            if (File.Exists(ConfigurationManager.AppSettings["AwardsPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsPath"], true))
                {
                    awards = JsonConvert.DeserializeObject<List<Award>>(sr.ReadToEnd());
                }

                if (awards.Any())
                {
                    id = awards[awards.Count-1].Id + 1;
                }
                else
                {
                    id = 1;
                }

                awards.Add(new Award() {Id = id, Title = award.Title});
            }
            else
            {
                awards.Add(new Award() {Id = 1, Title = award.Title});
            }

            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(awards));
            }
            return id;
        }

        public void DeleteById(int id)
        {
            List<Award> awards;
            if (File.Exists(ConfigurationManager.AppSettings["AwardsPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsPath"], true))
                {
                    awards = JsonConvert.DeserializeObject<List<Award>>(sr.ReadToEnd());
                }

                awards.RemoveAll(item => item.Id == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(awards));
                }
            }
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            if (File.Exists(ConfigurationManager.AppSettings["AwardsPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsPath"], true))
                {
                    awards = JsonConvert.DeserializeObject<List<Award>>(sr.ReadToEnd());
                }
            }

            return awards;
        }

        public Award GetAwardById(int id)
        {
            List<Award> awards = new List<Award>();
            if (File.Exists(ConfigurationManager.AppSettings["AwardsPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsPath"], true))
                {
                    awards = JsonConvert.DeserializeObject<List<Award>>(sr.ReadToEnd());
                }
            }

            return awards.FirstOrDefault(item => item.Id == id);
        }

        public void Update(int id, Award newAward)
        {
            List<Award> awards;
            if (File.Exists(ConfigurationManager.AppSettings["AwardsPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsPath"], true))
                {
                    awards = JsonConvert.DeserializeObject<List<Award>>(sr.ReadToEnd());
                }

                int count = awards.FindIndex(item => item.Id == id);
                int prevId = awards[count].Id; 
                awards[count] = new Award()
                {
                    Id = prevId,
                    Title = newAward.Title
                };

                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(awards));
                }
            }
        }
    }
}