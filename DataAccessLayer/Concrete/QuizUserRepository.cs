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
    public class QuizUserRepository : GenericRepository<QuizUser>, IQuizUserDal
    {
        public List<QuizUser> GetActiveQuizUserList()
        {
            using (var c = new Context())
            {
                var quiz = c.QuizUser.Include(x => x.Quiz).Include(x => x.User).Where(x => !x.IsDeleted).ToList();
                return quiz;
            }
        }

        public List<QuizUser> GetQuizByUserId(int id)
        {
            using (var c = new Context())
            {
                var quiz = c.QuizUser.Include(x => x.User).Include(x => x.Quiz).Where(q => q.UserId == id && !q.IsDeleted).ToList();
                return quiz;
            }
        }

        public List<QuizUser> GetQuizByUyeUserId(int? id)
        {
            using (var c = new Context())
            {
                var quiz = c.QuizUser.Include(x => x.User).Include(x => x.Quiz).Include(x => x.Quiz.Category).Where(q => q.UserId == id && !q.IsDeleted && q.IsActive && !q.IsFinished).ToList();
                return quiz;
            }
        }

        public List<QuizUser> GetQuizBySuccessUyeUserId(int? id)
        {
            using (var c = new Context())
            {
                var quiz = c.QuizUser.Include(x => x.User).Include(x => x.Quiz).Include(x => x.Quiz.Category).Where(q => q.UserId == id && !q.IsDeleted && q.IsActive && q.IsFinished).ToList();
                return quiz;
            }
        }
    }
}
