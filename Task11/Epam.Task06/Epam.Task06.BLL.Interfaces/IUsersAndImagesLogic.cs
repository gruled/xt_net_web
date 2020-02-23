using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IUsersAndImagesLogic
    {
        void AddLink(int userId, int imageId);
        IEnumerable<EntityAndImages> GetAll();
        void DeleteLinkByUserId(int id);
        void DeleteLinkByImageId(int id);
        void DeleteLink(int userId, int imageId);
    }
}
