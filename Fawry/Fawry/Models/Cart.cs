namespace Fawry.Models
{
    public class Cart
    {
        private readonly ICollection<CartItem> items = [];
        public ICollection<CartItem> Items => items;
        public decimal Subtotal => items.Sum(i => i.TotalPrice);

        public void Add(Product product, int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be at least 1");

            if (quantity > product.Quantity) throw new InvalidOperationException($"Not enough stock");

            items.Add(new CartItem(product, quantity));
        }

        public bool IsEmpty() => items.Count == 0;
    }
}