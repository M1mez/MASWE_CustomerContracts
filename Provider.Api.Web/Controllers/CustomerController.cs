using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Provider.Api.Web.Models;
using ServiceProvider.Database;
using ServiceProvider.Models;

namespace Provider.Api.Web.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ApiController
    {

        [Route("allCustomersStatus")]
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomersStatus()
        {
            return ExampleData.AllCustomers;
        }
        [Route("allCustomersBalance")]
        [HttpGet]
        public IEnumerable<BalanceCustomer> GetAllCustomersBalance()
        {
            return ExampleData.AllCustomers.Select(c => new BalanceCustomer(c));
        }
        [Route("customerSearch")]
        [HttpGet]
        public Customer GetProductsForCustomerByName()
        {
            var headers = Request.Headers;

            string customerName;
            customerName = headers.Contains("customerName") ? headers.GetValues("customerName").First() : "Arthur Koenig";

            return ExampleData.AllCustomers.Find(c => c.name == customerName);
        }
    }
}
