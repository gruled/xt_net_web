using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IUserRoleLogic
    {
        void AddRole(UserRole role);
        string GetRoleById(int id);
        IEnumerable<UserRole> GetAllRoles();
        void DeleteRoleById(int id);
        void UpdateRoleById(int id, UserRole role);
    }
}
