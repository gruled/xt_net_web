using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.BLL.Interfaces;
using Epam.Task06.DAL.Interfaces;
using Epam.Task06.Entities;

namespace Epam.Task06.BLL
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserDAO _userDao;
        public UserLogic(IUserDAO userDao)
        {
            _userDao = userDao;
        }
        public int Add(User user)
        {
            return _userDao.Add(user);
        }

        public void DeleteById(int id)
        {
            _userDao.DeleteById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }
    }
}
