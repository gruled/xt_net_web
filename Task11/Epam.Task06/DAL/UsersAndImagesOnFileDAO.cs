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
    public class UsersAndImagesOnFileDAO : IUsersAndImagesDAO
    {
        public void AddLink(int userId, int imageId)
        {
            List<EntityAndImages> usersAndImages;
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"], true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }
            }
            else
            {
                usersAndImages = new List<EntityAndImages>();
            }
            usersAndImages.Add(new EntityAndImages() { EntityId = userId, ImageId = imageId });
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(usersAndImages));
            }
        }

        public void DeleteLink(int userId, int imageId)
        {
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"]))
            {
                List<EntityAndImages> usersAndImages;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"],
                    true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }

                usersAndImages.RemoveAll(item => item.ImageId == imageId && item.EntityId == userId);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndImages));
                }
            }
        }

        public void DeleteLinkByImageId(int id)
        {
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"]))
            {
                List<EntityAndImages> usersAndAwards;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"],
                    true))
                {
                    usersAndAwards = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }

                usersAndAwards.RemoveAll(item => item.ImageId == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndAwards));
                }
            }
        }

        public void DeleteLinkByUserId(int id)
        {
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"]))
            {
                List<EntityAndImages> usersAndImages;
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"],
                    true))
                {
                    usersAndImages = JsonConvert.DeserializeObject<List<EntityAndImages>>(sr.ReadToEnd());
                }

                usersAndImages.RemoveAll(item => item.EntityId == id);
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"],
                    false))
                {
                    sw.Write(JsonConvert.SerializeObject(usersAndImages));
                }
            }
        }

        public IEnumerable<EntityAndImages> GetAll()
        {
            List<EntityAndImages> usersAndImages;
            if (File.Exists(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["UsersAndImagesLinksPath"], true))
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
