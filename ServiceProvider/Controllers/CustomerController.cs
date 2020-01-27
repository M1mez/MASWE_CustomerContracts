using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ServiceProvider.Database;
using ServiceProvider.Models;

namespace ServiceProvider.Controllers
{
    [System.Web.Http.Route("[controller]")]
    public class CustomerController : ApiController
    {

        [System.Web.Http.Route("allCustomersStatus")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Customer> GetAllCustomersStatus()
        {
            return ExampleData.AllCustomers;
        }
        [System.Web.Http.Route("allCustomersBalance")]
        [System.Web.Http.HttpGet]
        public IEnumerable<BalanceCustomer> GetAllCustomersBalance()
        {
            return ExampleData.AllCustomers.Select(c => new BalanceCustomer(c));
        }
        [System.Web.Http.Route("CustomerByName")]
        [System.Web.Http.HttpGet]
        public Customer GetProductsForCustomerByName()
        {
            var queryString = Request.GetQueryNameValuePairs()
                .ToDictionary(kv => kv.Key, kv => kv.Value,
                    StringComparer.OrdinalIgnoreCase);
            var customerName = queryString["customerName"];
            return ExampleData.AllCustomers.Find(c => c.Name == customerName);
        }
    }
}
