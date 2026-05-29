using System.Numerics;

namespace DotaParser52.Homeworks._28._02;

public abstract class OrderHandler<T> where T : INumber<T>
{
    protected OrderHandler<T>? Next { get; private set; }

    public OrderHandler<T> SetNext(OrderHandler<T> next)
    {
        Next = next;
        return next;
    }

    public T Process(Order<T> order)
    {
        return Process(order, order.BasePrice);
    }

    public virtual T Process(Order<T> order, T currentPrice)
    {

        if (Next is not null)
        {
            return Next.Process(order, currentPrice);
                    
        }
        return currentPrice;

        // var v = Next?.Process(order, currentPrice) ;
        // return v ?? currentPrice;
    }
}
