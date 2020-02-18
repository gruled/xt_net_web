using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Add(User user);
        void DeleteById(int id);
        IEnumerable<User> GetAll();
        User GetUserById(int id);
        void Update(int id, User newUser);
    }
}
