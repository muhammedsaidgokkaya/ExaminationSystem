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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questiondal;

        public QuestionManager(IQuestionDal questiondal)
        {
            _questiondal = questiondal;
        }

        public List<Question> GetList()
        {
            return _questiondal.GetListAll();
        }

        public List<Question> GetActiveList()
        {
            return _questiondal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(Question t)
        {
            _questiondal.Insert(t);
        }

        public void TDelete(Question t)
        {
            _questiondal.Delete(t);
        }

        public Question TGetById(int id)
        {
            return _questiondal.GetById(id);
        }

        public void TUpdate(Question t)
        {
            _questiondal.Update(t);
        }

        public List<Question> GetQuestionsByQuizId(int id)
        {
            return _questiondal.GetQuestionsByQuizId(id);
        }

        public List<Question> GetQuestionsByQuiz(int id)
        {
            return _questiondal.GetQuestionsByQuiz(id);
        }
    }
}
