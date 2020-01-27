using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer_AllCustomers_Status.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; } = "Standard";
    }
}
