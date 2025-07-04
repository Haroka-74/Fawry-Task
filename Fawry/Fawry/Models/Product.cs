namespace Fawry.Models
{
    public abstract class Product
    {
        private string? _name;
        private decimal _price;
        private int _quantity;

        public string Name
        {
            get => _name!;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name can't be empty");
                _name = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price can't be negative");
                _price = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative");
                _quantity = value;
            }
        }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString() => $"Product({Name}, {Price:C}, {Quantity})";
    }
}