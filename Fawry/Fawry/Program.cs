using Fawry.Models;
using Fawry.Services;

namespace Fawry
{
    public class Program
    {
        public static void Main()
        {

            var cartValidator = new CartValidator();
            var priceCalculator = new PriceCalculator();
            var receiptPrinter = new ReceiptPrinter();
            var inventoryManager = new InventoryManager();
            var shippingService = new ShippingService();
            var paymentProcessor = new PaymentProcessor();

            var checkoutService = new CheckoutService(cartValidator, priceCalculator, receiptPrinter, inventoryManager, shippingService, paymentProcessor);

            var cheese = new Cheese("Cheese", 100, 5, DateTime.Now.AddDays(7), 0.2m);
            var biscuits = new Biscuits("Biscuits", 150, 3, DateTime.Now.AddDays(30));
            var tv = new TV("TV", 500, 2, 15.0m);
            var scratchCard = new ScratchCard("Scratch Card", 10, 10);

            var customer = new Customer("Mohamed", 1000);

            Console.WriteLine(customer);

            try
            {
                var c1 = new Cheese("", 100, 5, DateTime.Now.AddDays(7), 0.2m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var c2 = new Cheese("Cheese", -100, 5, DateTime.Now.AddDays(7), 0.2m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var c2 = new Cheese("Cheese", 100, -5, DateTime.Now.AddDays(7), 0.2m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var cus1 = new Customer("Ahmed", -1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var customer2 = new Customer("Empty Cart Customer", 1000);
                checkoutService.Checkout(customer2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var customer3 = new Customer("Stock Test Customer", 2000);
                customer3.Cart.Add(tv, 5);

                checkoutService.Checkout(customer3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var customer4 = new Customer("Expired Test Customer", 1000);
                var cheese1 = new Cheese("Expired Cheese", 50, 3, DateTime.Now.AddDays(-1), 0.2m);

                customer4.Cart.Add(cheese1, 1);

                checkoutService.Checkout(customer4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var customer5 = new Customer("Poor Customer", 50);

                customer5.Cart.Add(tv, 1);

                checkoutService.Checkout(customer5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                var test = new Customer("Test Customer", 1000);

                test.Cart.Add(cheese, 2);
                test.Cart.Add(tv, 1);
                test.Cart.Add(scratchCard, 1);

                checkoutService.Checkout(test);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}