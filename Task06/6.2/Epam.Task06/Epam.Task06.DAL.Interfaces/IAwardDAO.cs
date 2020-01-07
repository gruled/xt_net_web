using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.Entities;

namespace Epam.Task06.DAL.Interfaces
{
    public interface IAwardDAO
    {
        int Add(Award award);
        IEnumerable<Award> GetAll();
    }
}
