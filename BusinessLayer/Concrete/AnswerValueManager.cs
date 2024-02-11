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
    public class AnswerValueManager : IAnswerValueService
    {
        IAnswerValueDal _answervaluedal;

        public AnswerValueManager(IAnswerValueDal answervaluedal)
        {
            _answervaluedal = answervaluedal;
        }

        public List<AnswerValue> GetList()
        {
            return _answervaluedal.GetListAll();
        }

        public List<AnswerValue> GetActiveList()
        {
            return _answervaluedal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(AnswerValue t)
        {
            _answervaluedal.Insert(t);
        }

        public void TDelete(AnswerValue t)
        {
            _answervaluedal.Delete(t);
        }

        public AnswerValue TGetById(int id)
        {
            return _answervaluedal.GetById(id);
        }

        public void TUpdate(AnswerValue t)
        {
            _answervaluedal.Update(t);
        }

        public List<AnswerValue> GetAnswerValuesByQuestionId(int id)
        {
            return _answervaluedal.GetAnswerValuesByQuestionId(id);
        }
    }
}
