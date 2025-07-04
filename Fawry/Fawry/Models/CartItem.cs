namespace Fawry.Models
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; }
        public decimal TotalPrice => Product.Price * Quantity;

        public CartItem(Product product, int quantity)
        {
            Product = product;

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be at least 1");

            Quantity = quantity;
        }

        public override string ToString() => $"{Product.Price} * {Quantity} = {TotalPrice}";
    }
}