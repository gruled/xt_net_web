using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.DAL.Interfaces;
using Epam.Task06.Entities;

namespace Epam.Task06.DAL
{
    public class MemoryAward : IAwardDAO
    {
        private readonly List<Award> list;

        public MemoryAward()
        {
            list = new List<Award>();
        }
        public int Add(Award award)
        {
            list.Add(award);
            return 0;
        }

        public void DeleteById(int id)
        {
            
        }

        public void Update(int id, string newTitle)
        {
            
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> myList = new List<Award>();
            foreach (var item in list)
            {
                myList.Add(item);
            }
            return myList;
        }
    }
}
