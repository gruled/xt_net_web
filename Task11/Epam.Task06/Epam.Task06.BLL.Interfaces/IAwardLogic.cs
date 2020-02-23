using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IAwardLogic
    {
        int Add(Award award);
        void DeleteById(int id);
        IEnumerable<Award> GetAll();
        Award GetAwardById(int id);
        void Update(int id, Award newAward);
    }
}
