using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string ProductCode { get; set; }
        public decimal InterestRate { get; set; }
    }
}
