using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dto;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public List<User> GetList()
        {
            return _userdal.GetListAll();
        }

        public List<User> GetActiveList()
        {
            return _userdal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(User t)
        {
            _userdal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userdal.Delete(t);
        }

        public User TGetById(int id)
        {
            return _userdal.GetById(id);
        }

        public void TUpdate(User t)
        {
            _userdal.Update(t);
        }

        public User UserLoginControl(User user)
        {
            return _userdal.UserLoginControl(user);
        }
    }
}
