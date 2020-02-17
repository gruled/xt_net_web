using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.BLL.Interfaces;
using Epam.Task06.DAL.Interfaces;

namespace Epam.Task06.BLL
{
    public class SettingsLogic : ISettingsLogic
    {
        private readonly ISettings _settingsDao;
        public SettingsLogic(ISettings settingsDao)
        {
            _settingsDao = settingsDao;
        }
        public string GetPath()
        {
            return _settingsDao.GetPath();
        }

        public string GetPathToUsers()
        {
            return _settingsDao.GetPathToUsers();
        }

        public void SetPath(string path)
        {
            _settingsDao.SetPath(path);
        }

        public void SetPathToUsers(string pathToUsers)
        {
            _settingsDao.SetPathToUsers(pathToUsers);
        }

        public string GetPathToImages()
        {
            return _settingsDao.GetPathToUsers();
        }

        public void SetPathToImages(string pathToImages)
        {
            _settingsDao.SetPathToImages(pathToImages);
        }
    }
}
