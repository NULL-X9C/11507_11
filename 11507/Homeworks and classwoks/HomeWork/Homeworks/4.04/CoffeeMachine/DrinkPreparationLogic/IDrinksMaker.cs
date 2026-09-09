using HomeWork.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;
using HomeWork.Homeworks._4._04.Config;
using HomeWork.Homeworks._4._04.Orders;

namespace HomeWork.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;

public interface IDrinksMaker
{
    public void Make(UserOrder order);
}