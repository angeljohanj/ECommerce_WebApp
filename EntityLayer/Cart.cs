using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cart
    {
        public int CartId { get; set; }
        public Clients OClient { get; set; }
        public Product OProduct { get; set; }
        public int Quantity { get; set; }
    }
}
