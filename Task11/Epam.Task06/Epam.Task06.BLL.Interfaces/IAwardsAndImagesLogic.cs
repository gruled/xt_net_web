using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IAwardsAndImagesLogic
    {
        void AddLink(int awardId, int imageId);
        IEnumerable<EntityAndImages> GetAll();
        void DeleteLinkByAwardId(int id);
        void DeleteLinkByImageId(int id);
        void DeleteLink(int awardId, int imageId);
    }
}
