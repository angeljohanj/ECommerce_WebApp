using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category
    {
        public int CatId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
