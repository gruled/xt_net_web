using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Epam.Task06.DependencyResolver;

namespace Epam.Task10_11.Models
{
    public class MyRoleProvider:RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var list = DependencyResolver.IWebUserLogic.GetAllWebUsers().First(item => item.Login == username);
            string[] t = GetRolesForUser(username);
            foreach (var item in t)
            {
                if (item.Equals(roleName))
                {
                    return true;
                }
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            var list = DependencyResolver.IWebUserLogic.GetAllWebUsers().FirstOrDefault(item => item.Login == username);
            string[] str = new string[] { DependencyResolver.IUserRoleLogic.GetRoleById(list.Role) };
            return str;
        }

        #region MyRegion

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        #endregion
        public override string ApplicationName { get; set; }
    }
}