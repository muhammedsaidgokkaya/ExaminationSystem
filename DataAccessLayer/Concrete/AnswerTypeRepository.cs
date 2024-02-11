using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class AnswerTypeRepository : GenericRepository<AnswerType>, IAnswerTypeDal
    {
    }
}
