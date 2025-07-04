using Fawry.Interfaces;
using Fawry.Models;

namespace Fawry.Services
{
    public class InventoryManager : IInventoryManager
    {
        public void UpdateInventory(Cart cart)
        {
            foreach (var item in cart.Items)
                item.Product.Quantity -= item.Quantity;
        }
    }
}