using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class QuestionDto : BaseDto
    {
        public string QuestionName { get; set; }
        public int AnswerTypeId { get; set; }
        public AnswerTypeDto AnswerTypeDto { get; set; }
        public int QuizId { get; set; }
        public QuizDto QuizDto { get; set; }
        public List<AnswerValueDto> AnswerValueDto { get; set; }
    }
}
