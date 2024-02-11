using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDal _userroledal;

        public UserRoleManager(IUserRoleDal userroledal)
        {
            _userroledal = userroledal;
        }

        public List<UserRole> GetList()
        {
            return _userroledal.GetListAll();
        }

        public List<UserRole> GetActiveList()
        {
            return _userroledal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(UserRole t)
        {
            _userroledal.Insert(t);
        }

        public void TDelete(UserRole t)
        {
            _userroledal.Delete(t);
        }

        public UserRole TGetById(int id)
        {
            return _userroledal.GetById(id);
        }

        public void TUpdate(UserRole t)
        {
            _userroledal.Update(t);
        }
        public List<UserRole> GetUserRoleByUserId(int id)
        {
            return _userroledal.GetUserRoleByUserId(id);
        }
    }
}
