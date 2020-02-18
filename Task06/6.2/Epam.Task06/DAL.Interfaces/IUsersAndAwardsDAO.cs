﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IUsersAndAwardsDAO
    {
        void AddLink(int userId, int awardId);
        IEnumerable<UsersAndAwards> GetAll();
        void DeleteLinkByUserId(int id);
        void DeleteLinkByAwardId(int id);
        void DeleteLink(int userId, int awardId);
    }
}
