using DotaParser52.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;
using DotaParser52.Homeworks._4._04.Config;

namespace DotaParser52.Homeworks._4._04.UserInterfasce;

public class MenuLogic
{
    public static void ShowMenu(List<MenuItem> menuItems)
    {
        Console.WriteLine("--- ДОСТУПНОЕ МЕНЮ ---");

        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i].RecipeName}");
        }
    }

    public static void ShowAvailableSizes(List<MenuItem.ServingSize> allowedSizes, MenuItem selectedItem)
    {
        Console.WriteLine($"\nДоступные размеры для {selectedItem.RecipeName}:");
        for (int i = 0; i < allowedSizes.Count; i++)
        {
            var s = allowedSizes[i];
            Console.WriteLine($"{i + 1}. {s.Label} ({s.Volume}мл) - {s.Price} руб.");
        }
    }
}