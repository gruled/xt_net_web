using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Epam.Task06.BLL.Interfaces;

namespace Epam.Task06.BLL
{
    public class AwardsAndImagesLogic : IAwardsAndImagesLogic
    {
        private readonly IAwardsAndImagesDAO _awardsAndImagesDao;

        public AwardsAndImagesLogic(IAwardsAndImagesDAO awardsAndImagesDAO)
        {
            _awardsAndImagesDao = awardsAndImagesDAO;
        }
        public void AddLink(int awardId, int imageId)
        {
            _awardsAndImagesDao.AddLink(awardId, imageId);
        }

        public void DeleteLink(int awardId, int imageId)
        {
            _awardsAndImagesDao.DeleteLink(awardId, imageId);
        }

        public void DeleteLinkByAwardId(int id)
        {
            _awardsAndImagesDao.DeleteLinkByAwardId(id);
        }

        public void DeleteLinkByImageId(int id)
        {
            _awardsAndImagesDao.DeleteLinkByImageId(id);
        }

        public IEnumerable<EntityAndImages> GetAll()
        {
            return _awardsAndImagesDao.GetAll();
        }
    }
}
