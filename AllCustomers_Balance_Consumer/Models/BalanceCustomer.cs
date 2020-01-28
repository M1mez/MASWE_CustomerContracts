using System.Linq;

namespace AllCustomers_Balance_Consumer.Models
{
    public class BalanceCustomer
    {
        public BalanceCustomer(Customer customer)
        {
            totalBalance = customer.financialProducts.Aggregate(0m, (acc, next) => acc + next.balance);
            name = customer.name;
        }
        public decimal totalBalance { get; }

        public string name { get; }
    }
}
