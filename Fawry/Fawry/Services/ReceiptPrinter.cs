using Fawry.Interfaces;
using Fawry.Models;

namespace Fawry.Services
{
    public class ReceiptPrinter : IReceiptPrinter
    {
        public virtual void PrintReceipt(Cart cart, CheckoutResult result, Customer customer)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("-- Checkout receipt --");
            Console.WriteLine("----------------------");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.TotalPrice}");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Subtotal: {result.Subtotal}");
            Console.WriteLine($"Shipping: {result.Shipping}");
            Console.WriteLine($"Amount: {result.Total}");
            Console.WriteLine();
            Console.WriteLine($"Customer balance after payment: {customer.Balance}");
        }
    }
}