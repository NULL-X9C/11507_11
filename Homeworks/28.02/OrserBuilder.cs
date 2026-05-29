using System.Numerics;

namespace DotaParser52.Homeworks._28._02;

public class OrderBuilder<T> : IIdStep, IPriceStep<T>, IFinalStep<T> where T : INumber<T>
{
    private int _id;
    private T _basePrice;
    
    public static IIdStep Create() => new OrderBuilder<T>();

    public IPriceStep<T> SetId<T>(int id) where T : INumber<T>
    {
        _id = id;
        return (IPriceStep<T>)this;
    }

    public IFinalStep<T> SetBasePrice(T price)
    {
        _basePrice = price;
        return this;
    }

    public Order<T> Build()
    {
        return new Order<T>(_id, _basePrice);
    }
}