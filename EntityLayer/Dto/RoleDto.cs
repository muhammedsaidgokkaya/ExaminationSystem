using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class RoleDto : BaseDto
    {
        public string RoleName { get; set; }
        public List<UserRoleDto> UserRoleDto { get; set; }
    }
}
