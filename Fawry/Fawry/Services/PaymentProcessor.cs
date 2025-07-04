using Fawry.Interfaces;
using Fawry.Models;

namespace Fawry.Services
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Customer customer, decimal amount)
        {
            if (customer.Balance < amount)
                throw new InvalidOperationException("Insufficient user balance");

            customer.ReduceCustomerBalance(amount);
        }
    }
}