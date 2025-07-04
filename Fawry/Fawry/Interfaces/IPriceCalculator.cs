using Fawry.Models;

namespace Fawry.Interfaces
{
    public interface IPriceCalculator
    {
        CheckoutResult Calculate(Cart cart);
    }
}