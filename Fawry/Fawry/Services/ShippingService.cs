using Fawry.Interfaces;

namespace Fawry.Services
{
    public class ShippingService : IShippingService
    {
        public void Ship(List<IShippable> items)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("---  Shipment notice  ---");
            Console.WriteLine("-------------------------");

            var groups = items.GroupBy(i => i.GetName());

            decimal total = 0;

            foreach (var group in groups)
            {
                int count = group.Count();
                decimal weight = group.First().GetWeight();

                Console.WriteLine($"{count}x {group.Key} {weight * count * 1000} g");

                total += weight * count;
            }

            Console.WriteLine();
            Console.WriteLine($"Total package weight: {total:F1} kg");
            Console.WriteLine();
        }
    }
}