using Fawry.Interfaces;
using Fawry.Models;

namespace Fawry.Services
{
    public class CartValidator : ICartValidator
    {
        public void Validate(Cart cart)
        {
            if (cart.IsEmpty())
                throw new InvalidOperationException("Cart is empty");

            foreach (var item in cart.Items)
            {
                if (item.Product is IExpirable expirable && expirable.Expiration < DateTime.Now)
                    throw new InvalidOperationException($"Product is expired");

                if (item.Quantity > item.Product.Quantity)
                    throw new InvalidOperationException($"No enough stock");
            }
        }
    }
}