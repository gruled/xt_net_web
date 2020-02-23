using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Epam.Task06.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyResolver.DependencyResolver.IUserRoleLogic.AddRole(new UserRole(){Title = "admin"});
            DependencyResolver.DependencyResolver.IUserRoleLogic.AddRole(new UserRole() { Title = "user" });
            DependencyResolver.DependencyResolver.IWebUserLogic.AddWebUser(new WebUser(){Login = "admin", Password = "admin", Role = 0});
            DependencyResolver.DependencyResolver.IWebUserLogic.AddWebUser(new WebUser() { Login = "123", Password = "456", Role = 1 });
            DependencyResolver.DependencyResolver.AwardLogic.Add(new Award(){Title = "Hero of WWII"});
            DependencyResolver.DependencyResolver.AwardLogic.Add(new Award() { Title = "Medal of honor" });
            DependencyResolver.DependencyResolver.AwardLogic.Add(new Award() { Title = "Some Award" });
            DependencyResolver.DependencyResolver.UserLogic.Add(new User(){Name = "Ivan", Age = 22, DateOfBirth = new DateTime(1997,4,6)});
            DependencyResolver.DependencyResolver.UserLogic.Add(new User() { Name = "Alex", Age = 22, DateOfBirth = new DateTime(1997, 9, 3) });
            DependencyResolver.DependencyResolver.UsersAndAwardsLogic.AddLink(0,0);
            DependencyResolver.DependencyResolver.UsersAndAwardsLogic.AddLink(0, 1);
            DependencyResolver.DependencyResolver.UsersAndAwardsLogic.AddLink(1, 0);
            //DependencyResolver.DependencyResolver.IWebUserLogic.AddWebUser(new WebUser() { Login = "Ivan", Password = "123456", Role = 1 });

            //Tools tools = new Tools();
            //tools.Run();
        }
    }
}
