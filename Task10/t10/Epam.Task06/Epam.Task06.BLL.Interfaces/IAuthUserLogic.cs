﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06.Entities;

namespace Epam.Task06.BLL.Interfaces
{
    public interface IAuthUserLogic
    {
        int Add(AuthUser authUser);
        IEnumerable<AuthUser> GetAllAuthUsers();
        int ChangeAdmin(string name);

    }
}
