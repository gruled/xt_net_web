using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Epam.Task06.BLL.Interfaces;

namespace Epam.Task06.BLL
{
    public class ImagesLogic : IImagesLogic
    {
        private readonly IImagesDAO _imagesDao;
        private readonly IUsersAndImagesLogic _usersAndImagesLogic;
        private readonly IAwardsAndImagesLogic _awardsAndImagesLogic;

        public ImagesLogic(IImagesDAO imagesDAO, IUsersAndImagesLogic usersAndImagesLogic, IAwardsAndImagesLogic awardsAndImagesLogic)
        {
            _imagesDao = imagesDAO;
            _usersAndImagesLogic = usersAndImagesLogic;
            _awardsAndImagesLogic = awardsAndImagesLogic;
        }
        public int AddImage(Image image)
        {
           return _imagesDao.AddImage(image);
        }

        public void DeleteImageById(int id)
        {
            _imagesDao.DeleteImageById(id);
            _awardsAndImagesLogic.DeleteLinkByImageId(id);
            _usersAndImagesLogic.DeleteLinkByImageId(id);
        }

        public Image GetImageById(int id)
        {
            return _imagesDao.GetImageById(id);
            
            //return Convert.ToBase64String(_imagesDao.GetImageById(id).Value));
        }



        public void UpdateImageById(int id, Image image)
        {
            _imagesDao.UpdateImageById(id, image);
        }

        public IEnumerable<Image> GetAll()
        {
            return _imagesDao.GetAll();
        }
    }
}
