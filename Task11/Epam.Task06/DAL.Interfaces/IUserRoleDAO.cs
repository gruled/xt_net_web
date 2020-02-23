using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IUserRoleDAO
    {
        void AddRole(UserRole role);
        string GetRoleById(int id);
        IEnumerable<UserRole> GetAllRoles();
        void DeleteRoleById(int id);
        void UpdateRoleById(int id, UserRole role);
    }
}
