using DataAccessLayer.Abstract;
using EntityLayer.EF;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserDal
    {
        public User UserLoginControl(User user)
        {
            using (var c = new Context())
            {
                var userLogin = c.User.Include(x => x.UserRole).Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                return userLogin;
            }
        }
    }
}
