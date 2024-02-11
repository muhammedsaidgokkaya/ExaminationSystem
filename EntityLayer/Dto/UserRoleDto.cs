using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class UserRoleDto : BaseDto
    {
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public int RoleId { get; set; }
        public RoleDto RoleDto { get; set; }
    }
}
