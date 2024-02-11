using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQuestionService : IGenericService<Question>
    {
        public List<Question> GetQuestionsByQuizId(int id);
        public List<Question> GetQuestionsByQuiz(int id);
    }
}
