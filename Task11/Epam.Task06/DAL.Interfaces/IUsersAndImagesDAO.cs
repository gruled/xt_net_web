using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IUsersAndImagesDAO
    {
        void AddLink(int userId, int imageId);
        IEnumerable<EntityAndImages> GetAll();
        void DeleteLinkByUserId(int id);
        void DeleteLinkByImageId(int id);
        void DeleteLink(int userId, int imageId);
    }
}
