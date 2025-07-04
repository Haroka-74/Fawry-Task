namespace Fawry.Models
{
    public class Customer
    {
        private string? _name;
        private decimal _balance;

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

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance can't be negative");
                _balance = value;
            }
        }

        public Cart Cart { get; private set; }

        public Customer(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
            Cart = new Cart();
        }

        public void ReduceCustomerBalance(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount can't be negative");

            if (amount > Balance)
                throw new InvalidOperationException("Can't reduce balance under zero");

            Balance -= amount;
        }

        public override string ToString() => $"Customer({Name}, {Balance})";
    }
}