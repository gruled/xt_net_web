using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IImagesDAO
    {
        int AddImage(Image image);
        void DeleteImageById(int id);
        Image GetImageById(int id);
        void UpdateImageById(int id, Image image);
        IEnumerable<Image> GetAll();
    }
}
