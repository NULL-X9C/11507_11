using System.Numerics;

namespace HomeWork.Homeworks._28._02;

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
