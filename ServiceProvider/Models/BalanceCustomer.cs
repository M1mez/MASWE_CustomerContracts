using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Models
{
    public class BalanceCustomer
    {
        public BalanceCustomer(Customer customer)
        {
            _customer = customer;
        }

        private readonly Customer _customer;
        public decimal TotalBalance => _customer.FinancialProducts.Aggregate(0m, (acc, next) => acc + next.Balance);
        public string Name => _customer.Name;
    }
}
