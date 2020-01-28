using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Models
{
    public class Product
    {
        public string name { get; set; }
        public decimal balance { get; set; }
        public string productCode { get; set; }
        public decimal interestRate { get; set; }
    }
}
