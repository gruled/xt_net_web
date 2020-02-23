using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Epam.Task06.BLL.Interfaces;

namespace Epam.Task06.BLL
{
    public class UsersAndImagesLogic : IUsersAndImagesLogic
    {
        private readonly IUsersAndImagesDAO _usersAndImagesDao;

        public UsersAndImagesLogic(IUsersAndImagesDAO usersAndImagesDAO)
        {
            _usersAndImagesDao = usersAndImagesDAO;
        }
        public void AddLink(int userId, int imageId)
        {
            _usersAndImagesDao.AddLink(userId, imageId);
        }

        public void DeleteLink(int userId, int imageId)
        {
            _usersAndImagesDao.DeleteLink(userId, imageId);
        }

        public void DeleteLinkByImageId(int id)
        {
            _usersAndImagesDao.DeleteLinkByImageId(id);
        }

        public void DeleteLinkByUserId(int id)
        {
            _usersAndImagesDao.DeleteLinkByUserId(id);
        }

        public IEnumerable<EntityAndImages> GetAll()
        {
            return _usersAndImagesDao.GetAll();
        }
    }
}
