using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class User : Base
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRole { get; set; }
        public List<QuizUser> QuizUser { get; set; }
    }
}
