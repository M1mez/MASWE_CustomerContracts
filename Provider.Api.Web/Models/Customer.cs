using System;
using System.Collections.Generic;
using ServiceProvider.Models;

namespace Provider.Api.Web.Models
{
    public class Customer
    {
        public string name { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string emailAddress { get; set; }
        public string status { get; set; }
        public List<Product> financialProducts { get; set; }
    }
}
