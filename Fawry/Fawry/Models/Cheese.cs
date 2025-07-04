using Fawry.Interfaces;

namespace Fawry.Models
{
    public class Cheese : Product, IExpirable, IShippable
    {
        public DateTime Expiration { get; set; }
        public decimal Weight { get; set; }

        public Cheese(string name, decimal price, int quantity, DateTime expiration, decimal weight) : base(name, price, quantity)
        {
            Expiration = expiration;
            Weight = weight;
        }

        public string GetName() => Name;

        public decimal GetWeight() => Weight;
    }
}