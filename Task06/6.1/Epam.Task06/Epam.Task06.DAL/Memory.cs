using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.DAL.Interfaces;
using Epam.Task06.Entities;

namespace Epam.Task06.DAL
{
    public class Memory : IUserDAO
    { 
        private readonly List<User> list;

        public Memory()
        {
            list = new List<User>();
        }

        public int Add(User user)
        {
            list.Add(user);
            return 0;
        }

        public void DeleteById(int id)
        {
            list.RemoveAll(item => item.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            List<User> myList = new List<User>();
            foreach (var item in list)
            {
                myList.Add(item);
            }
            return myList;
        }
    }
}
