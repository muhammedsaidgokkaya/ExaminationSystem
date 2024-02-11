using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class AnswerTypeDto : BaseDto
    {
        public string TypeName { get; set; }
        public List<QuestionDto> QuestionDto { get; set; }
    }
}
