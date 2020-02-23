﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Epam.Task06.BLL.Interfaces;

namespace Epam.Task06.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDAO _awardDao;
        private readonly IUsersAndAwardsDAO _usersAndAwardsDao;
        private readonly IAwardsAndImagesLogic _awardsAndImagesLogic;

        public AwardLogic(IAwardDAO awardDao, IUsersAndAwardsDAO usersAndAwardsDao, IAwardsAndImagesLogic awardsAndImagesLogic)
        {
            this._awardDao = awardDao;
            this._usersAndAwardsDao = usersAndAwardsDao;
            this._awardsAndImagesLogic = awardsAndImagesLogic;
        }
        public int Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public void DeleteById(int id)
        {
            _awardDao.DeleteById(id);
            _usersAndAwardsDao.DeleteLinkByAwardId(id);
            _awardsAndImagesLogic.DeleteLinkByAwardId(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public Award GetAwardById(int id)
        {
            return _awardDao.GetAwardById(id);
        }

        public void Update(int id, Award newAward)
        {
            _awardDao.Update(id, newAward);
        }
    }
}
