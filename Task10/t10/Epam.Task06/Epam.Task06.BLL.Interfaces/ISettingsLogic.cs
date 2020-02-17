using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06.BLL.Interfaces
{
    public interface ISettingsLogic
    {
        string GetPath();
        void SetPath(string path);

        string GetPathToUsers();
        void SetPathToUsers(string pathToUsers);
        string GetPathToImages();
        void SetPathToImages(string pathToImages);
    }
}
