using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IAwardsAndImagesDAO
    {
        void AddLink(int awardId, int imageId);
        IEnumerable<EntityAndImages> GetAll();
        void DeleteLinkByAwardId(int id);
        void DeleteLinkByImageId(int id);
        void DeleteLink(int awardId, int imageId);
    }
}