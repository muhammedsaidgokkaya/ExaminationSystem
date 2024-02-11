using DataAccessLayer.Abstract;
using EntityLayer.EF;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionDal
    {
        public List<Question> GetQuestionsByQuizId(int id)
        {
            using (var c = new Context())
            {
                var quiz = c.Question.Include(x => x.Quiz).Include(x => x.AnswerType).Where(q => q.QuizId == id && !q.IsDeleted).ToList();
                return quiz;
            }
        }

        public List<Question> GetQuestionsByQuiz(int id)
        {
            using (var c = new Context())
            {
                var quiz = c.Question.Include(x => x.Quiz).Include(x => x.AnswerValue).Where(q => q.QuizId == id && !q.IsDeleted && q.IsActive).ToList();
                return quiz;
            }
        }
    }
}
