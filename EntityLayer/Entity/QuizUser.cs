using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class QuizUser : Base
    {
        public DateTime StartQuiz { get; set; }
        public DateTime FinishQuiz { get; set; }
        public int UserScore { get; set; }
        public bool IsFinished { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
