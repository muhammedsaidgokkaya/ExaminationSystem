using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnswerValueService : IGenericService<AnswerValue>
    {
        public List<AnswerValue> GetAnswerValuesByQuestionId(int id);
    }
}
