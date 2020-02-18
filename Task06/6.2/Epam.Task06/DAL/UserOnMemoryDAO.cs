using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class UserOnMemoryDAO : IUserDAO
    {
        private readonly List<User> _users;
        private int _idCount;

        public UserOnMemoryDAO()
        {
            _users = new List<User>();
            _idCount = 0;
        }
        public void Add(User user)
        {
            var tmp = user;
            tmp.Id = _idCount;
            _users.Add(tmp);
            _idCount++;
        }

        public void DeleteById(int id)
        {
            _users.RemoveAll(item => item.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.Find(item => item.Id == id);
        }

        public void Update(int id, User newUser)
        {
            var count = _users.FindIndex(item => item.Id == id);
            _users[count] = new User()
            {
                Id = _users[count].Id,
                Name = newUser.Name,
                Age = newUser.Age,
                DateOfBirth = newUser.DateOfBirth
            };
        }
    }
}
