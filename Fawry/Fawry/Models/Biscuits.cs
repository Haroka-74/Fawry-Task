using Fawry.Interfaces;

namespace Fawry.Models
{
    public class Biscuits : Product, IExpirable
    {
        public DateTime Expiration { get; set; }

        public Biscuits(string name, decimal price, int quantity, DateTime expiration) : base(name, price, quantity)
        {
            Expiration = expiration;
        }
    }
}