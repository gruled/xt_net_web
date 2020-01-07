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
        public string GetPath()
        {
            return _path;
        }

        public void SetPath(string path)
        {
            _path = path;
        }
    }
}
