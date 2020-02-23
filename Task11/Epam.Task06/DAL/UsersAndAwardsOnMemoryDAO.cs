using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class UsersAndAwardsOnMemoryDAO : IUsersAndAwardsDAO
    {
        private readonly List<UsersAndAwards> _usersAndAwards;

        public UsersAndAwardsOnMemoryDAO()
        {
            _usersAndAwards = new List<UsersAndAwards>();
        }

        public void AddLink(int userId, int awardId)
        {
            _usersAndAwards.Add(new UsersAndAwards() {IdUser = userId, IdAward = awardId});
        }

        public void DeleteLink(int userId, int awardId)
        {
            _usersAndAwards.RemoveAll(item => item.IdAward == awardId&&item.IdUser==userId);
        }

        public void DeleteLinkByAwardId(int id)
        {
            _usersAndAwards.RemoveAll(item => item.IdAward == id);
        }

        public void DeleteLinkByUserId(int id)
        {
            _usersAndAwards.RemoveAll(item => item.IdUser == id);
        }

        public IEnumerable<UsersAndAwards> GetAll()
        {
            return _usersAndAwards;
        }
    }
}