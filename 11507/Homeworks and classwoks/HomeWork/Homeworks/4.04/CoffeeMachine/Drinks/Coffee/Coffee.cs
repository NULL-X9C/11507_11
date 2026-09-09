using System.Linq;

namespace HomeWork.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;

public class Coffee
{
    public Coffee(string name, int baseVolume, Dictionary<string, int> ingredients)
    {
        Name = name;
        BaseVolume = baseVolume;
        Ingredients = ingredients;
        if (Ingredients.Where(i => i.Key != "CoffeeBeans" && i.Key != "Sugar")
                .Select(i => i.Value)
                .Sum() != BaseVolume)
        {
            throw new ArgumentException("Сумма ингредиентов должна равняться BaseVolume");
        }
    }
    
    public Coffee(){ }

    public string Name { get; set; }
    public int BaseVolume { get; set; }
    public Dictionary<string, int> Ingredients{ get; set; } = new();
}