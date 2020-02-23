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
    public class WebUserLogic : IWebUserLogic
    {
        private readonly IWebUserDAO _webUserDao;

        public WebUserLogic(IWebUserDAO webUserDao)
        {
            this._webUserDao = webUserDao;
        }

        public void AddWebUser(WebUser user)
        {
            this._webUserDao.AddWebUser(user);
        }

        public void DeleteWebUserById(int id)
        {
            this._webUserDao.DeleteWebUserById(id);
        }

        public IEnumerable<WebUser> GetAllWebUsers()
        {
            return this._webUserDao.GetAllWebUsers();
        }

        public int GetRoleById(int id)
        {
            return this._webUserDao.GetRoleById(id);
        }

        public WebUser GetWebUserById(int id)
        {
            return this._webUserDao.GetWebUserById(id);
        }

        public void UpdateWebUserById(int id, WebUser webUser)
        {
            this._webUserDao.UpdateWebUserById(id, webUser);
        }
    }
}