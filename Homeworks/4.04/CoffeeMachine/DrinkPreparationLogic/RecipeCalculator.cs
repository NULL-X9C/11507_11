using DotaParser52.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;
using DotaParser52.Homeworks._4._04.Config;

namespace DotaParser52.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;

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
