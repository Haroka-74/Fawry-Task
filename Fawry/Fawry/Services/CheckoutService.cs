using Fawry.Interfaces;
using Fawry.Models;

namespace Fawry.Services
{
    public class CheckoutService
    {
        private readonly ICartValidator _cartValidator;
        private readonly IPriceCalculator _priceCalculator;
        private readonly IReceiptPrinter _receiptPrinter;
        private readonly IInventoryManager _inventoryManager;
        private readonly IShippingService _shippingService;
        private readonly IPaymentProcessor _paymentProcessor;

        public CheckoutService(ICartValidator cartValidator, IPriceCalculator priceCalculator, IReceiptPrinter receiptPrinter, IInventoryManager inventoryManager, IShippingService shippingService, IPaymentProcessor paymentProcessor)
        {
            _cartValidator = cartValidator;
            _priceCalculator = priceCalculator;
            _receiptPrinter = receiptPrinter;
            _inventoryManager = inventoryManager;
            _shippingService = shippingService;
            _paymentProcessor = paymentProcessor;
        }

        public void Checkout(Customer customer)
        {
            var cart = customer.Cart;

            _cartValidator.Validate(cart);

            var result = _priceCalculator.Calculate(cart);

            _paymentProcessor.ProcessPayment(customer, result.Total);

            _inventoryManager.UpdateInventory(cart);

            if (result.ShippableItems.Count != 0)
                _shippingService.Ship(result.ShippableItems);

            _receiptPrinter.PrintReceipt(cart, result, customer);
        }
    }
}