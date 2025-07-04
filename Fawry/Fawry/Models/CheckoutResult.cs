using Fawry.Interfaces;

namespace Fawry.Models
{
    public class CheckoutResult
    {
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Shipping { get; set; }
        public List<IShippable> ShippableItems { get; set; } = [];
    }
}