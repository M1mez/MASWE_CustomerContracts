using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public List<Product> FinancialProducts { get; set; }
    }
}
