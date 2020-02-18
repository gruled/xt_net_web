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

        public UserLogic(IUserDAO userDao, IUsersAndAwardsDAO usersAndAwardsDao)
        {
            this._userDao = userDao;
            this._usersAndAwardsDao = usersAndAwardsDao;
        }
        public void Add(User user)
        {
            _userDao.Add(user);
        }

        public void DeleteById(int id)
        {
            _userDao.DeleteById(id);
            _usersAndAwardsDao.DeleteLinkByUserId(id);
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
