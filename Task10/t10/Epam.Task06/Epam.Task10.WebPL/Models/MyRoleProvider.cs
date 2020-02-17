using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Epam.Task06.DependencyResolver;

namespace Epam.Task10.WebPL.Models
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool IsUserInRole(string username, string roleName)
        {
            var list = DependencyResolver.AuthUserLogic.GetAllAuthUsers().Where(item=>item.Name.Equals(username));
            if (roleName.Equals("Admin"))
            {
                list.Where(item => item.IsAdmin);
            }
            else
            {
                list.Where(item => !item.IsAdmin);
            }

            if (list.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            var list = DependencyResolver.AuthUserLogic.GetAllAuthUsers().Where(item => item.Name.Equals(username));
            List<string> rolesList = new List<string>();
            foreach (var item in list)
            {
                if (item.IsAdmin)
                {
                    rolesList.Add("Admin");
                }
                else
                {
                    rolesList.Add("User");
                }
            }

            return rolesList.ToArray();
        }

        #region MyRegion


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}