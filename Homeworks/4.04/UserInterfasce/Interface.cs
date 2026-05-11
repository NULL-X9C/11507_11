using System.Text.Json;
using DotaParser52.Homeworks._4._04.CoffeeMachine;
using DotaParser52.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;
using DotaParser52.Homeworks._4._04.CoffeeMachine.Validation.InputValidators;
using DotaParser52.Homeworks._4._04.GetObjFromFile;
using DotaParser52.Homeworks._4._04.Orders;

namespace DotaParser52.Homeworks._4._04.UserInterfasce;

public class Interface
{
    public static void StartOrder()
    {
        var loadedConfig = Getting.LoadConfig();
    
        if (loadedConfig == null || loadedConfig.Resources == null || loadedConfig.Resources.Count == 0)
        {
            Console.WriteLine("КРИТИЧЕСКАЯ ОШИБКА: Конфиг загрузился пустым!");
            return;
        }

        var master = new DrinkMaster(loadedConfig);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== КОФЕЙНЯ ОТКРЫТА ===");
            
            var availableMenu = master.GetFilteredMenu();
            
            if (!availableMenu.Any())
            {
                Console.WriteLine("\n[!] Ресурсы закончились. Напитки недоступны.");
            }
            else
            {
                MenuLogic.ShowMenu(availableMenu);
            }

            Console.WriteLine("\nВведите номер напитка, 'admin' для пополнения или 'exit' для закрытия смены:");
            string input = Console.ReadLine()?.ToLower() ?? "";

            // ВЫХОД (Конец смены)
            if (input == "exit")
            {
                EndOfShift.Finish(loadedConfig, master);
                break; 
            }
            
            // АДМИН-ПАНЕЛЬ
            if (input == "admin")
            {
                ShowAdminPanel(master);
                continue;
            }

            // ЗАКАЗ
            if (int.TryParse(input, out int drinkIdx) && drinkIdx > 0 && drinkIdx <= availableMenu.Count)
            {
                var selectedMenuItem = availableMenu[drinkIdx - 1];
                
                var allowedSizes = selectedMenuItem.Sizes
                    .Where(s => selectedMenuItem.RecipeName != null && master.CanMake(selectedMenuItem.RecipeName, s))
                    .ToList();
                
                MenuLogic.ShowAvailableSizes(allowedSizes, selectedMenuItem);
                
                string sizeInput = InputOrchestrator.ReadUntilValid(
                    () => Console.ReadLine(),
                    sIn => int.TryParse(sIn, out int idx) && idx > 0 && idx <= allowedSizes.Count,
                    "Выберите номер размера:"
                )!;
                
                var selectedSize = allowedSizes[int.Parse(sizeInput) - 1];
                var order = new UserOrder(selectedMenuItem.RecipeName!, selectedSize);

                if (master.CanMake(order.RecipeName, order.ServingSize))
                {
                    master.MakeDrink(order);
                    Console.WriteLine($"\n[OK] Заберите ваш заказ! {order}");
                    Console.WriteLine("Приятного аппетита!");
                }

                Console.WriteLine("\nНажмите любую клавишу для следующего покупателя...");
                Console.ReadKey();
            }
        }
    }

    private static void ShowAdminPanel(DrinkMaster master)
    {
        Console.Clear();
        Console.WriteLine("=== ПАНЕЛЬ АДМИНИСТРАТОРА ===");
        
        Console.WriteLine("Введите название ресурса для пополнения (Water, Milk, CoffeeBeans и т.д.):");
        string resourceName = Console.ReadLine() ?? "";

        Console.WriteLine("Введите количество");
        string amountInput = InputOrchestrator.ReadUntilValid(
            () => Console.ReadLine(),
            input => int.TryParse(input, out int val) && val > 0,
            "Введите количество (целое число):"
        )!;

        master.RefillResource(resourceName, int.Parse(amountInput));
        
        Console.WriteLine("\nРесурсы успешно добавлены! Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
}
