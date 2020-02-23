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
    public class UserRoleLogic : IUserRoleLogic
    {
        private readonly IUserRoleDAO _userRoleDao;

        public UserRoleLogic(IUserRoleDAO userRoleDAO)
        {
            this._userRoleDao = userRoleDAO;
        }
        public void AddRole(UserRole role)
        {
            this._userRoleDao.AddRole(role);
        }

        public void DeleteRoleById(int id)
        {
            this._userRoleDao.DeleteRoleById(id);
        }

        public IEnumerable<UserRole> GetAllRoles()
        {
            return this._userRoleDao.GetAllRoles();
        }

        public string GetRoleById(int id)
        {
            return this._userRoleDao.GetRoleById(id);
        }

        public void UpdateRoleById(int id, UserRole role)
        {
            this._userRoleDao.UpdateRoleById(id, role);
        }
    }
}
