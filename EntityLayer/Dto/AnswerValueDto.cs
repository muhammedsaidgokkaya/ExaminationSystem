using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class AnswerValueDto : BaseDto
    {
        public string ValueName { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }
        public QuestionDto QuestionDto { get; set; }
    }
}
