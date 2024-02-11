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
    public class RoleManager : IRoleService
    {
        IRoleDal _roledal;

        public RoleManager(IRoleDal roledal)
        {
            _roledal = roledal;
        }

        public List<Role> GetList()
        {
            return _roledal.GetListAll();
        }

        public List<Role> GetActiveList()
        {
            return _roledal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(Role t)
        {
            _roledal.Insert(t);
        }

        public void TDelete(Role t)
        {
            _roledal.Delete(t);
        }

        public Role TGetById(int id)
        {
            return _roledal.GetById(id);
        }

        public void TUpdate(Role t)
        {
            _roledal.Update(t);
        }
    }
}
