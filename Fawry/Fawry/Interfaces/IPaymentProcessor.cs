using Fawry.Models;

namespace Fawry.Interfaces
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(Customer customer, decimal amount);
    }
}