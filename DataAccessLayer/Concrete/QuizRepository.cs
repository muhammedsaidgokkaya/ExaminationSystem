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
    public class QuizRepository : GenericRepository<Quiz> , IQuizDal
    {
        public List<Quiz> GetActiveCategoryList()
        {
            using (var c = new Context())
            {
                var quiz = c.Quiz.Include(x => x.Category).Where(x => !x.IsDeleted).ToList();
                return quiz;
            }
        }
    }
}
