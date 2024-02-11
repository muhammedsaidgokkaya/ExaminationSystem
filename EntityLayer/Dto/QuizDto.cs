using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class QuizDto : BaseDto
    {
        public string QuizName { get; set; }
        public int QuizDuration { get; set; }
        public string QuizDescription { get; set; }
        public int QuizScore { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto CategoryDto { get; set; }
        public List<QuestionDto> QuestionDto { get; set; }
        public List<QuizUserDto> QuizUserDto { get; set; }
    }
}
