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
    public class UsersAndAwardsOnFileDAO : IUsersAndAwardsDAO
    {
        public void AddLink(int userId, int awardId)
        {
            List<UsersAndAwards> usersAndAwards;
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"], true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<UsersAndAwards>>(sr.ReadToEnd());
                }
            }
            else
            {
                usersAndAwards = new List<UsersAndAwards>();
            }
            usersAndAwards.Add(new UsersAndAwards(){IdUser = userId, IdAward = awardId});
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(usersAndAwards));
            }
        }

        public void DeleteLink(int userId, int awardId)
        {
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"]))
            {
                List<UsersAndAwards> usersAndAwards;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"],
                    true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<UsersAndAwards>>(sr.ReadToEnd());
                }

                usersAndAwards.RemoveAll(item => item.IdAward == awardId&& item.IdUser==userId);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndAwards));
                }
            }
        }

        public void DeleteLinkByAwardId(int id)
        {
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"]))
            {
                List<UsersAndAwards> usersAndAwards;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"],
                    true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<UsersAndAwards>>(sr.ReadToEnd());
                }

                usersAndAwards.RemoveAll(item => item.IdAward == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndAwards));
                }
            }
        }

        public void DeleteLinkByUserId(int id)
        {
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"]))
            {
                List<UsersAndAwards> usersAndAwards;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"],
                    true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<UsersAndAwards>>(sr.ReadToEnd());
                }

                usersAndAwards.RemoveAll(item => item.IdUser == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndAwards));
                }
            }
        }

        public IEnumerable<UsersAndAwards> GetAll()
        {
            List<UsersAndAwards> usersAndAwards;
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndAwardsLinksPath"], true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<UsersAndAwards>>(sr.ReadToEnd());
                }
            }
            else
            {
                usersAndAwards = new List<UsersAndAwards>();
            }

            return usersAndAwards;
        }
    }
}
