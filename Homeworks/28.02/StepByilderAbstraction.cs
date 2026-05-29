using System.Numerics;

namespace DotaParser52.Homeworks._28._02;

public interface IIdStep
{
    IPriceStep<T> SetId<T>(int id) where T : INumber<T>;
}

public interface IPriceStep<T> where T : INumber<T>
{
    IFinalStep<T> SetBasePrice(T price);
}

public interface IFinalStep<T> where T : INumber<T>
{
    Order<T> Build();
}