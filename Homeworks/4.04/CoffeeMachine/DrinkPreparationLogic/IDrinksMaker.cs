using DotaParser52.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;
using DotaParser52.Homeworks._4._04.Config;
using DotaParser52.Homeworks._4._04.Orders;

namespace DotaParser52.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;

public interface IDrinksMaker
{
    public void Make(UserOrder order);
}