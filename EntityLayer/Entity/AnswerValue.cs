using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class AnswerValue : Base
    {
        public string ValueName { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
