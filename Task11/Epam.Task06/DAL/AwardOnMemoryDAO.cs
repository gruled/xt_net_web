using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class AwardOnMemoryDAO : IAwardDAO
    {
        private readonly List<Award> _awards;
        private int _idCount;

        public AwardOnMemoryDAO()
        {
            _awards = new List<Award>();
            _idCount = 1;
        }
        public int Add(Award award)
        {
            var tmp = award;
            tmp.Id = _idCount;
            _awards.Add(tmp);
            _idCount++;
            return _idCount - 1;
        }

        public void DeleteById(int id)
        {
            _awards.RemoveAll(item => item.Id == id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awards;
        }

        public Award GetAwardById(int id)
        {
            return _awards.Find(item => item.Id == id);
        }

        public void Update(int id, Award newAward)
        {
            var count = _awards.FindIndex(item => item.Id == id);
            _awards[count] = new Award()
            {
                Id = _awards[count].Id,
                Title = newAward.Title
            };
        }
    }
}
