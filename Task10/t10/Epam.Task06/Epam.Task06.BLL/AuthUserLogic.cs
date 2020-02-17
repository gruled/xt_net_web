using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.BLL.Interfaces;
using Epam.Task06.DAL.Interfaces;
using Epam.Task06.Entities;

namespace Epam.Task06.BLL
{
    public class AuthUserLogic : IAuthUserLogic
    {
        private readonly IAuthUser _authUser;

        public AuthUserLogic(IAuthUser authUser)
        {
            _authUser = authUser;
        }
        public int Add(AuthUser authUser)
        {
            return _authUser.Add(authUser);
        }

        public int ChangeAdmin(string name)
        {
            return _authUser.ChangeAdmin(name);
        }

        public IEnumerable<AuthUser> GetAllAuthUsers()
        {
            return _authUser.GetAllAuthUsers();
        }
    }
}
