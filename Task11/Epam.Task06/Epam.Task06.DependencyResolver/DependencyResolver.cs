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
        private static readonly IUserRoleDAO _userRoleDao;
        private static readonly IUserRoleLogic _userRoleLogic;
        private static readonly IWebUserDAO _webUserDao;
        private static readonly IWebUserLogic _webUserLogic;
        private static readonly IImagesDAO _imagesDao;
        private static readonly IImagesLogic _imagesLogic;
        private static readonly IUsersAndImagesDAO _usersAndImagesDao;
        private static readonly IUsersAndImagesLogic _usersAndImagesLogic;
        private static readonly IAwardsAndImagesDAO _awardsAndImagesDao;
        private static readonly IAwardsAndImagesLogic _awardsAndImagesLogic;

        public static IUserDAO UserDAO => _userDao;
        public static IUserLogic UserLogic => _userLogic;
        public static IAwardDAO AwardDAO => _awardDao;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IUsersAndAwardsDAO UsersAndAwardsDao => _usersAndAwardsDao;
        public static IUsersAndAwardsLogic UsersAndAwardsLogic => _usersAndAwardsLogic;
        public static IUserRoleDAO IUserRoleDao => _userRoleDao;
        public static IUserRoleLogic IUserRoleLogic => _userRoleLogic;
        public static IWebUserDAO IWebUserDao => _webUserDao;
        public static IWebUserLogic IWebUserLogic => _webUserLogic;
        public static IImagesDAO ImagesDao => _imagesDao;
        public static IImagesLogic ImagesLogic => _imagesLogic;
        public static IUsersAndImagesDAO UsersAndImagesDao => _usersAndImagesDao;
        public static IUsersAndImagesLogic UsersAndImagesLogic => _usersAndImagesLogic;
        public static IAwardsAndImagesDAO AwardsAndImagesDao => _awardsAndImagesDao;
        public static IAwardsAndImagesLogic AwardsAndImagesLogic => _awardsAndImagesLogic;

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
                    _webUserDao = new WebUserFileDao();
                    _userRoleDao = new UserRoleFileDAO();
                    _imagesDao = new ImagesDAO();
                    _usersAndImagesDao = new UsersAndImagesOnFileDAO();
                    _awardsAndImagesDao = new AwardsAndImagesDAO();
                    break;
                case "Database":
                    _userDao = new UserDatabaseDAO();
                    _awardDao = new AwardDatabaseDAO();
                    _usersAndAwardsDao = new UsersAndAwardsDatabaseDAO();
                    _webUserDao = new WebUserDatabaseDAO();
                    _userRoleDao = new UserRoleDatabaseDAO();
                    _imagesDao = new ImagesDatabaseDAO();
                    _usersAndImagesDao = new UsersAndImagesDatabaseDAO();
                    _awardsAndImagesDao = new AwardsAndImagesDatabaseDAO();
                    break;
            }

            _usersAndAwardsLogic = new UsersAndAwardsLogic(_usersAndAwardsDao);
            _webUserLogic = new WebUserLogic(_webUserDao);
            _userRoleLogic = new UserRoleLogic(_userRoleDao);
            _usersAndImagesLogic = new UsersAndImagesLogic(_usersAndImagesDao);
            _awardsAndImagesLogic = new AwardsAndImagesLogic(_awardsAndImagesDao);
            _userLogic = new UserLogic(_userDao, _usersAndAwardsDao, _usersAndImagesLogic);
            _awardLogic = new AwardLogic(_awardDao, _usersAndAwardsDao, _awardsAndImagesLogic);
            _imagesLogic = new ImagesLogic(_imagesDao, _usersAndImagesLogic, _awardsAndImagesLogic);
        }
    }
}