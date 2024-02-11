using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IQuizUserDal : IGenericDal<QuizUser>
    {
        public List<QuizUser> GetActiveQuizUserList();
        public List<QuizUser> GetQuizByUserId(int id);
        public List<QuizUser> GetQuizByUyeUserId(int? id);
        public List<QuizUser> GetQuizBySuccessUyeUserId(int? id);
    }
}
