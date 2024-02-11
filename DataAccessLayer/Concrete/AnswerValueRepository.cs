using DataAccessLayer.Abstract;
using EntityLayer.EF;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class AnswerValueRepository : GenericRepository<AnswerValue>, IAnswerValueDal
    {
        public List<AnswerValue> GetAnswerValuesByQuestionId(int id)
        {
            using (var c = new Context())
            {
                var quiz = c.AnswerValue.Include(x => x.Question).Where(q => q.QuestionId == id && !q.IsDeleted).ToList();
                return quiz;
            }
        }
    }
}
