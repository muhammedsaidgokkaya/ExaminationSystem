using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Quiz : Base
    {
        public string QuizName { get; set; }
        public int QuizDuration { get; set; }
        public string QuizDescription { get; set; }
        public int QuizScore { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Question> Question { get; set; }
        public List<QuizUser> QuizUser { get; set; }
    }
}
