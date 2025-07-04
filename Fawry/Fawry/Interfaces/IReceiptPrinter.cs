using Fawry.Models;

namespace Fawry.Interfaces
{
    public interface IReceiptPrinter
    {
        void PrintReceipt(Cart cart, CheckoutResult result, Customer customer);
    }
}