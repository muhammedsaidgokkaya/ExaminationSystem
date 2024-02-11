using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Category : Base
    {
        public string CategoryName { get; set; }
        public List<Quiz> Quiz { get; set; }
    }
}
