﻿using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserRoleDal : IGenericDal<UserRole>
    {
        public List<UserRole> GetUserRoleByUserId(int id);
    }
}
