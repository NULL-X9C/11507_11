using System.Numerics;

namespace DotaParser52.Homeworks._28._02;

public class Order<T> where T : INumber<T>
{
    public int Id { get; }
    public T BasePrice { get; }

    public Order(int id, T basePrice)
    {
        Id = id;
        BasePrice = basePrice;
    }
}
