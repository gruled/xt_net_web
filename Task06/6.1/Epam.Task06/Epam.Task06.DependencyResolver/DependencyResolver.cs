using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Epam.Task06.BLL;
using Epam.Task06.BLL.Interfaces;
using Epam.Task06.DAL;
using Epam.Task06.DAL.Interfaces;

namespace Epam.Task06.DependencyResolver
{
    public static class DependencyResolver
    {
        private static readonly IUserLogic _userLogic;
        private static readonly IUserDAO _userDao;
        private static readonly ISettingsLogic _settingsLogic;
        private static readonly ISettings _settingsDao;
        public static ISettingsLogic SettingsLogic => _settingsLogic;
        public static IUserLogic UserLogic => _userLogic;
        public static IUserDAO UserDao => _userDao;
        public static ISettings SettingsDao => _settingsDao;
        static DependencyResolver()
        {
            _settingsDao = new Settings();
            _settingsLogic = new SettingsLogic(_settingsDao);
            if (ConfigurationManager.AppSettings["DAL"].Equals("Memory"))
            {
                _userDao = new Memory();
            }
            else
            {
                if (ConfigurationManager.AppSettings["DAL"].Equals("TextFile"))
                {
                    _userDao = new TextFiles(SettingsLogic);
                }
            }
            _userLogic = new UserLogic(_userDao);
        }
    }
}
