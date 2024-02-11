using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class AnswerType : Base
    {
        public string TypeName { get; set; }
        public List<Question> Question { get; set; }
    }
}
