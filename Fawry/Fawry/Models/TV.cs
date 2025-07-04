using Fawry.Interfaces;

namespace Fawry.Models
{
    public class TV : Product, IShippable
    {
        public decimal Weight { get; set; }

        public TV(string name, decimal price, int quantity, decimal weight) : base(name, price, quantity)
        {
            Weight = weight;
        }

        public string GetName() => Name;
        public decimal GetWeight() => Weight;
    }
}