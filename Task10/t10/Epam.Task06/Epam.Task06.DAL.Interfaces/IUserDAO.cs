using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.Entities;

namespace Epam.Task06.DAL.Interfaces
{
    public interface IUserDAO
    {
        int Add(User user);
        void DeleteById(int id);
        IEnumerable<User> GetAll();
        void UpdateUser(User before, User after);
    }
}
