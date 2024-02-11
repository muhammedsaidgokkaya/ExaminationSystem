using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Role : Base
    {
        public string RoleName { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
