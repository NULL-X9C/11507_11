using System.Numerics;

namespace HomeWork.Homeworks._28._02;

public class Handlers<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _discountAmount;

    public Handlers(T discountAmount)
    {
        _discountAmount = discountAmount;
    }

    public override T Process(Order<T> order, T currentPrice)
    {
        T newPrice = currentPrice - _discountAmount;
        return base.Process(order, newPrice);
    }
    
}

public class TaxHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _taxFactor;

    public TaxHandler(double taxFactor)
    {
        _taxFactor = T.CreateChecked(taxFactor);
    }

    public override T Process(Order<T> order, T currentPrice)
    {
        T newPrice = currentPrice * _taxFactor;
        return base.Process(order,  newPrice);
    }
}

public class ValidationHAndler<T> : OrderHandler<T> where  T : INumber<T>
{
    public override T Process(Order<T> order, T currentPrice)
    {
        if (currentPrice < T.Zero) throw new InvalidOperationException();
        return base.Process(order, currentPrice);
    }
}