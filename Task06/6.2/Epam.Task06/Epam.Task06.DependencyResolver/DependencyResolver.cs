using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using Epam.Task06.BLL;
using Epam.Task06.BLL.Interfaces;

namespace Epam.Task06.DependencyResolver
{
    public static class DependencyResolver
    {
        private static readonly IUserDAO _userDao;
        private static readonly IUserLogic _userLogic;
        private static readonly IAwardDAO _awardDao;
        private static readonly IAwardLogic _awardLogic;
        private static readonly IUsersAndAwardsDAO _usersAndAwardsDao;
        private static readonly IUsersAndAwardsLogic _usersAndAwardsLogic;

        public static IUserDAO UserDAO => _userDao;
        public static IUserLogic UserLogic => _userLogic;
        public static IAwardDAO AwardDAO => _awardDao;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IUsersAndAwardsDAO UsersAndAwardsDao => _usersAndAwardsDao;
        public static IUsersAndAwardsLogic UsersAndAwardsLogic => _usersAndAwardsLogic;

        static DependencyResolver()
        {
            switch (ConfigurationManager.AppSettings["DAL"])
            {
                case "Memory":
                    _userDao = new UserOnMemoryDAO();
                    _awardDao = new AwardOnMemoryDAO();
                    _usersAndAwardsDao = new UsersAndAwardsOnMemoryDAO();
                    break;
                case "File":
                    _userDao = new UserOnFileDAO();
                    _awardDao = new AwardOnFileDAO();
                    _usersAndAwardsDao = new UsersAndAwardsOnFileDAO();
                    break;
                case "Database":
                    break;
            }

            _userLogic = new UserLogic(_userDao, _usersAndAwardsDao);
            _awardLogic = new AwardLogic(_awardDao, _usersAndAwardsDao);
            _usersAndAwardsLogic = new UsersAndAwardsLogic(_usersAndAwardsDao);
        }
    }
}