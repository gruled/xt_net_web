using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IAwardDAO
    {
        void Add(Award award);
        void DeleteById(int id);
        IEnumerable<Award> GetAll();
        Award GetAwardById(int id);
        void Update(int id, Award newAward);
    }
}
