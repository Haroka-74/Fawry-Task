namespace Fawry.Interfaces
{
    public interface IExpirable
    {
        DateTime Expiration { get; set; }
    }
}