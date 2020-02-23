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
    public class UsersAndAwardsLogic : IUsersAndAwardsLogic
    {
        private readonly IUsersAndAwardsDAO _usersAndAwardsDao;

        public UsersAndAwardsLogic(IUsersAndAwardsDAO usersAndAwardsDAO)
        {
            _usersAndAwardsDao = usersAndAwardsDAO;
        }

        public void AddLink(int userId, int awardId)
        {
            _usersAndAwardsDao.AddLink(userId, awardId);
        }

        public void DeleteLink(int userId, int awardId)
        {
            _usersAndAwardsDao.DeleteLink(userId, awardId);
        }

        public void DeleteLinkByAwardId(int id)
        {
            _usersAndAwardsDao.DeleteLinkByAwardId(id);
        }

        public void DeleteLinkByUserId(int id)
        {
            _usersAndAwardsDao.DeleteLinkByUserId(id);
        }

        public IEnumerable<UsersAndAwards> GetAll()
        {
            return _usersAndAwardsDao.GetAll();
        }
    }
}
