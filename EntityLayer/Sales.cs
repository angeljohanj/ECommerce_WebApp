using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Sales
    {
        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public int TotalProduct { get; set; }
        public int TotalAmount { get; set; }
        public string Contact { get; set; }
        public int DistrictId { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string TransactionId { get; set; }
        public string SaleDate { get; set; }        
        public List<SaleDetails> SaleDetails { get; set; }

    }
}
