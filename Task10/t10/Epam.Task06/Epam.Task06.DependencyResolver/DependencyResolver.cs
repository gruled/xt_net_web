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
        private static readonly IAwardLogic _awardLogic;
        private static readonly IUserDAO _userDao;
        private static readonly IAwardDAO _awardDao;
        private static readonly ISettingsLogic _settingsLogic;
        private static readonly ISettings _settingsDao;
        private static readonly IAuthUserLogic _authUserLogic;
        private static readonly IAuthUser _authUserDao;


        public static IAuthUserLogic AuthUserLogic => _authUserLogic;
        public static IAuthUser AuthUser => _authUserDao;
        public static ISettingsLogic SettingsLogic => _settingsLogic;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IAwardDAO AwardDao => _awardDao;
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
                _awardDao = new MemoryAward();
            }
            else
            {
                if (ConfigurationManager.AppSettings["DAL"].Equals("TextFile"))
                {
                    _userDao = new TextFiles(SettingsLogic);
                    _awardDao = new TextFileAward(SettingsLogic);
                    SettingsLogic.SetPath(ConfigurationManager.AppSettings["PathToFile"]);
                    SettingsLogic.SetPathToUsers(ConfigurationManager.AppSettings["PathToAuthFile"]);
                    SettingsLogic.SetPathToImages(ConfigurationManager.AppSettings["PathToImages"]);
                }
            }
            _authUserDao = new AuthUserTextFile(_settingsLogic);
            _authUserLogic = new AuthUserLogic(_authUserDao);
            _userLogic = new UserLogic(_userDao);
            _awardLogic = new AwardLogic(_awardDao);
        }
    }
}
