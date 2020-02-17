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
        void DeleteById(int id);
        IEnumerable<Award> GetAll();
        void Update(int id, string title);
    }
}
