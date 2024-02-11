using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserRoleDto> UserRoleDto { get; set; }
        public List<QuizUserDto> QuizUserDto { get; set; }
    }
}
