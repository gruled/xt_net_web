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
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAO _userDao;
        private readonly IUsersAndAwardsDAO _usersAndAwardsDao;
        private readonly IUsersAndImagesLogic _usersAndImagesLogic;

        public UserLogic(IUserDAO userDao, IUsersAndAwardsDAO usersAndAwardsDao, IUsersAndImagesLogic usersAndImagesLogic)
        {
            this._userDao = userDao;
            this._usersAndAwardsDao = usersAndAwardsDao;
            this._usersAndImagesLogic = usersAndImagesLogic;
        }
        public int Add(User user)
        {
            return _userDao.Add(user);
        }

        public void DeleteById(int id)
        {
            _userDao.DeleteById(id);
            _usersAndAwardsDao.DeleteLinkByUserId(id);
            _usersAndImagesLogic.DeleteLinkByUserId(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public void Update(int id, User newUser)
        {
            _userDao.Update(id, newUser);
        }
    }
}
