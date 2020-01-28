using System.Linq;

namespace Provider.Api.Web.Models
{
    public class BalanceCustomer
    {
        public BalanceCustomer(Customer customer)
        {
            _customer = customer;
        }

        private readonly Customer _customer;
        public decimal TotalBalance => _customer.financialProducts.Aggregate(0m, (acc, next) => acc + next.balance);
        public string Name => _customer.name;
    }
}
