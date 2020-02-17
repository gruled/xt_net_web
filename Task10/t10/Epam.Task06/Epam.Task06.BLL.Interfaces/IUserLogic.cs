using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IUserLogic
    {
        int Add(User user);
        IEnumerable<User> GetAll();
        void DeleteById(int id);
        void UpdateUser(User before, User after);

    }
}
