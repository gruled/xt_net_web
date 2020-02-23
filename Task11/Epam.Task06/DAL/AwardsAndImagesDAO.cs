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
    public class AwardsAndImagesDAO : IAwardsAndImagesDAO
    {
        public void AddLink(int awardId, int imageId)
        {
            List<EntityAndImages> usersAndImages;
            if (File.Exists(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"], true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }
            }
            else
            {
                usersAndImages = new List<EntityAndImages>();
            }
            usersAndImages.Add(new EntityAndImages() { EntityId = awardId, ImageId = imageId });
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(usersAndImages));
            }
        }

        public void DeleteLink(int awardId, int imageId)
        {
            if (File.Exists(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"]))
            {
                List<EntityAndImages> usersAndImages;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"],
                    true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }

                usersAndImages.RemoveAll(item => item.ImageId == imageId && item.EntityId == awardId);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndImages));
                }
            }
        }

        public void DeleteLinkByImageId(int id)
        {
            if (File.Exists(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"]))
            {
                List<EntityAndImages> usersAndAwards;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"],
                    true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }

                usersAndAwards.RemoveAll(item => item.ImageId == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndAwards));
                }
            }
        }

        public void DeleteLinkByAwardId(int id)
        {
            if (File.Exists(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"]))
            {
                List<EntityAndImages> usersAndImages;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"],
                    true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }

                usersAndImages.RemoveAll(item => item.EntityId == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndImages));
                }
            }
        }

        public IEnumerable<EntityAndImages> GetAll()
        {
            List<EntityAndImages> usersAndImages;
            if (File.Exists(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AwardsAndImagesLinksPath"], true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }
            }
            else
            {
                usersAndImages = new List<EntityAndImages>();
            }

            return usersAndImages;
        }
    }
}
