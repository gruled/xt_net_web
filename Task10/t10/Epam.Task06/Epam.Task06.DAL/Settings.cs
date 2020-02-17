using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.DAL.Interfaces;

namespace Epam.Task06.DAL
{
    public class Settings : ISettings
    {
        private string _path;
        private string _pathToUsers;
        private string _pathToImages;

        public string GetPath()
        {
            return _path;
        }

        public string GetPathToImages()
        {
            return _pathToImages;
        }

        public string GetPathToUsers()
        {
            return _pathToUsers;
        }

        public void SetPath(string path)
        {
            _path = path;
        }

        public void SetPathToImages(string pathToImages)
        {
            _pathToImages = pathToImages;
        }

        public void SetPathToUsers(string pathToUsers)
        {
            _pathToUsers = pathToUsers;
        }
    }
}
