using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.BLL.Interfaces;
using Epam.Task06.DAL.Interfaces;
using Epam.Task06.Entities;

namespace Epam.Task06.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDAO _awardDao;
        public AwardLogic(IAwardDAO awardDao)
        {
            _awardDao = awardDao;
        }
        public int Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public void DeleteById(int id)
        {
            _awardDao.DeleteById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public void UpdateAward(int id, string title)
        {
            _awardDao.Update(id, title);
        }
    }
}
