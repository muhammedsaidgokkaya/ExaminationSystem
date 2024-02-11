using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Question : Base
    {
        public string QuestionName { get; set; }
        public int AnswerTypeId { get; set; }
        public AnswerType AnswerType { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public List<AnswerValue> AnswerValue { get; set; }
    }
}
