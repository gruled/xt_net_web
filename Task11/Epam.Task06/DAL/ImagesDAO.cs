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
    public class ImagesDAO : IImagesDAO
    {
        public int AddImage(Image image)
        {
            List<Image> images = new List<Image>();
            int id=1;
            if (File.Exists(ConfigurationManager.AppSettings["ImagesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["ImagesPath"], true))
                {
                    images = JsonConvert.DeserializeObject<List<Image>>(sr.ReadToEnd());
                }
                if (images.Any())
                {
                    id = images[images.Count - 1].Id + 1;
                }
                else
                {
                    id = 1;
                }

                images.Add(new Image() {Id = id, Value = image.Value});
            }
            else
            {
                images.Add(new Image() {Id = 1, Value = image.Value});
            }

            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["ImagesPath"], false))
            {
                sw.Write(JsonConvert.SerializeObject(images));
            }

            return id;
        }

        public void DeleteImageById(int id)
        {
            List<Image> images;
            if (File.Exists(ConfigurationManager.AppSettings["ImagesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["ImagesPath"], true))
                {
                    images = JsonConvert.DeserializeObject<List<Image>>(sr.ReadToEnd());
                }

                images.RemoveAll(item => item.Id == id);
            }
        }

        public Image GetImageById(int id)
        {
            List<Image> images = new List<Image>();
            if (File.Exists(ConfigurationManager.AppSettings["ImagesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["ImagesPath"], true))
                {
                    images = JsonConvert.DeserializeObject<List<Image>>(sr.ReadToEnd());
                }
            }

            return images.FirstOrDefault(item => item.Id == id);
        }

        public void UpdateImageById(int id, Image image)
        {
            List<Image> images;
            if (File.Exists(ConfigurationManager.AppSettings["ImagesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["ImagesPath"], true))
                {
                    images = JsonConvert.DeserializeObject<List<Image>>(sr.ReadToEnd());
                }

                int count = images.FindIndex(item => item.Id == id);
                int prevId = images[count].Id;
                images[count] = new Image()
                {
                    Id = prevId,
                    Value = image.Value
                };
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["ImagesPath"], false))
                {
                    sw.Write(JsonConvert.SerializeObject(images));
                }
            }
        }

        public IEnumerable<Image> GetAll()
        {
            List<Image> images = new List<Image>();
            if (File.Exists(ConfigurationManager.AppSettings["ImagesPath"]))
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["ImagesPath"], true))
                {
                    images = JsonConvert.DeserializeObject<List<Image>>(sr.ReadToEnd());
                }
            }

            return images;
        }
    }
}