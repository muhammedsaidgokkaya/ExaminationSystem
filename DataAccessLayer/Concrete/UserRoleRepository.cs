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
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleDal
    {
        public List<UserRole> GetUserRoleByUserId(int id)
        {
            using (var c = new Context())
            {
                var quiz = c.UserRole.Include(x => x.User).Include(x => x.Role).Where(q => q.UserId == id && !q.IsDeleted).ToList();
                return quiz;
            }
        }
    }
}
