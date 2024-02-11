using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQuizUserService : IGenericService<QuizUser>
    {
        public List<QuizUser> GetActiveQuizUserList();
        public List<QuizUser> GetQuizByUserId(int id);
        public List<QuizUser> GetQuizByUyeUserId(int? id);
        public List<QuizUser> GetQuizBySuccessUyeUserId(int? id);
    }
}
