using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IUserDAO
    {
        int Add(User user);
        void DeleteById(int id);
        IEnumerable<User> GetAll();
        User GetUserById(int id);
        void Update(int id, User newUser);
    }
}
