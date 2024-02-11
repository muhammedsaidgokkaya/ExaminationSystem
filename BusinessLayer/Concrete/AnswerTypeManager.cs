using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnswerTypeManager : IAnswerTypeService
    {
        IAnswerTypeDal _answertypedal;

        public AnswerTypeManager(IAnswerTypeDal answertypedal)
        {
            _answertypedal = answertypedal;
        }

        public List<AnswerType> GetList()
        {
            return _answertypedal.GetListAll();
        }

        public List<AnswerType> GetActiveList()
        {
            return _answertypedal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(AnswerType t)
        {
            _answertypedal.Insert(t);
        }

        public void TDelete(AnswerType t)
        {
            _answertypedal.Delete(t);
        }

        public AnswerType TGetById(int id)
        {
            return _answertypedal.GetById(id);
        }

        public void TUpdate(AnswerType t)
        {
            _answertypedal.Update(t);
        }
    }
}
