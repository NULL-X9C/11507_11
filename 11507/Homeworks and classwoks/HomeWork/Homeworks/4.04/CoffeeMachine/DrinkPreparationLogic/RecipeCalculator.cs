using HomeWork.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;
using HomeWork.Homeworks._4._04.Config;

namespace HomeWork.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;

public static class RecipeCalculator
{
    public static Dictionary<string, int> CalculateRequiredIngredients(Coffee recipe, MenuItem.ServingSize size)
    {
        double ratio = (double)size.Volume / recipe.BaseVolume;
        return recipe.Ingredients.ToDictionary(
            i => i.Key,
            i => (int)Math.Ceiling(i.Value * ratio)
        );
    }
}
