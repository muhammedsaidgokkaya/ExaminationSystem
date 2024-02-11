using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.EF;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class QuizManager : IQuizService
    {
        IQuizDal _quizdal;

        public QuizManager(IQuizDal quizdal)
        {
            _quizdal = quizdal;
        }

        public List<Quiz> GetList()
        {
            return _quizdal.GetListAll();
        }

        public List<Quiz> GetActiveList()
        {
            return _quizdal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(Quiz t)
        {
            _quizdal.Insert(t);
        }

        public void TDelete(Quiz t)
        {
            _quizdal.Delete(t);
        }

        public Quiz TGetById(int id)
        {
            return _quizdal.GetById(id);
        }

        public void TUpdate(Quiz t)
        {
            _quizdal.Update(t);
        }

        public List<Quiz> GetActiveCategoryList()
        {
            return _quizdal.GetActiveCategoryList();
        }
    }
}
