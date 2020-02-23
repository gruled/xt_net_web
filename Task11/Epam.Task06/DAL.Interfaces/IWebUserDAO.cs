using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IWebUserDAO
    {
        void AddWebUser(WebUser user);
        int GetRoleById(int id);
        WebUser GetWebUserById(int id);
        IEnumerable<WebUser> GetAllWebUsers();
        void DeleteWebUserById(int id);
        void UpdateWebUserById(int id, WebUser webUser);
    }
}
