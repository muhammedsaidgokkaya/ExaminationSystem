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
    public class QuizUserManager : IQuizUserService
    {
        IQuizUserDal _quizuserdal;

        public QuizUserManager(IQuizUserDal quizuserdal)
        {
            _quizuserdal = quizuserdal;
        }

        public List<QuizUser> GetList()
        {
            return _quizuserdal.GetListAll();
        }

        public List<QuizUser> GetActiveList()
        {
            return _quizuserdal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(QuizUser t)
        {
            _quizuserdal.Insert(t);
        }

        public void TDelete(QuizUser t)
        {
            _quizuserdal.Delete(t);
        }

        public QuizUser TGetById(int id)
        {
            return _quizuserdal.GetById(id);
        }

        public void TUpdate(QuizUser t)
        {
            _quizuserdal.Update(t);
        }

        public List<QuizUser> GetActiveQuizUserList()
        {
            return _quizuserdal.GetActiveQuizUserList();
        }

        public List<QuizUser> GetQuizByUserId(int id)
        {
            return _quizuserdal.GetQuizByUserId(id);
        }

        public List<QuizUser> GetQuizByUyeUserId(int? id)
        {
            return _quizuserdal.GetQuizByUyeUserId(id);
        }

        public List<QuizUser> GetQuizBySuccessUyeUserId(int? id)
        {
            return _quizuserdal.GetQuizBySuccessUyeUserId(id);
        }
    }
}
