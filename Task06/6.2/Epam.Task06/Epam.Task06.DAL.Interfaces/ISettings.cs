using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06.DAL.Interfaces
{
    public interface ISettings
    {
        string GetPath();
        void SetPath(string path);
    }
}
