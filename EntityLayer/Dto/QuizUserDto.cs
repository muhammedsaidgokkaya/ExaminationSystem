using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class QuizUserDto : BaseDto
    {
        public DateTime StartQuiz { get; set; }
        public DateTime FinishQuiz { get; set; }
        public int UserScore { get; set; }
        public bool IsFinished { get; set; }
        public int QuizId { get; set; }
        public QuizDto QuizDto { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }

    }
}
