using Fawry.Interfaces;
using Fawry.Models;

namespace Fawry.Services
{
    public class PriceCalculator : IPriceCalculator
    {

        public virtual CheckoutResult Calculate(Cart cart)
        {
            List<IShippable> shippableItems = [];
            decimal subtotal = 0;

            foreach (var item in cart.Items)
            {
                subtotal += item.TotalPrice;

                if (item.Product is IShippable shippable)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        shippableItems.Add(shippable);
                    }
                }
            }

            decimal shipping = CalculateShipping(subtotal, shippableItems);
            decimal total = subtotal + shipping;

            return new CheckoutResult
            {
                Subtotal = subtotal,
                Shipping = shipping,
                Total = total,
                ShippableItems = shippableItems
            };
        }

        private static decimal CalculateShipping(decimal subtotal, List<IShippable> shippableItems)
        {
            if (shippableItems.Count == 0)
                return 0;

            return subtotal * 0.15m;
        }

    }
}