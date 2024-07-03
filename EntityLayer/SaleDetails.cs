using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SaleDetails
    {

        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public Product OProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
