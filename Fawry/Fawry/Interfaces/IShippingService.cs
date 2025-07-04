namespace Fawry.Interfaces
{
    public interface IShippingService
    {
        void Ship(List<IShippable> items);
    }
}