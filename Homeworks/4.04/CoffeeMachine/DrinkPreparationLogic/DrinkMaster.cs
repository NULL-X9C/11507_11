using System.Text.Json;
using DotaParser52.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;
using DotaParser52.Homeworks._4._04.Config;
using DotaParser52.Homeworks._4._04.Orders;
using DotaParser52.Homeworks._4._04.SaveToFile;

namespace DotaParser52.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;

public class DrinkMaster : IDrinksMaker
{
    public void Make(UserOrder order)
    {
        MakeDrink(order);
    }
    
    private readonly Config1 _config1;
    private readonly InventoryService _inventory;
    private Coffee GetRicepe(string recipeName) =>
        _config1.Recipes.ContainsKey(recipeName) ? _config1.Recipes[recipeName] :
        throw new Exception("Not found recipe " + recipeName);
    
    // Список для хранения истории за сессию
    private readonly List<UserOrder> _salesHistory = new();

    public DrinkMaster(Config1 config1)
    {
        _config1 = config1;
        _inventory = new InventoryService(config1.Resources);
    }
    
    public void MakeDrink(UserOrder order)
    {
        var recipe = _config1.Recipes.ContainsKey(order.RecipeName) ? _config1.Recipes[order.RecipeName] :
                throw new Exception("Not found recipe " + order.RecipeName);
        var required = RecipeCalculator.
            CalculateRequiredIngredients(recipe, order.ServingSize);
        
        _config1.Resources = _inventory.Consume(required);
        
        // Сохраняем 
        Saving.SaveConfig(_config1);
        
        // Добавляем в историю
        _salesHistory.Add(order);
        
        SaveOrderToLog(order);
        
        Console.WriteLine($"Приготовлено: {order.RecipeName}. В кассу: {order.Price}");
    }

    // Метод для получения истории 
    public IReadOnlyList<UserOrder> GetHistory() => _salesHistory.AsReadOnly();
    
    private void SaveOrderToLog(UserOrder order)
    {
        string logEntry = JsonSerializer.Serialize(order);
    
        // Дописываем в конец файла.
        File.AppendAllLines("sales_history.log", new[] { logEntry });
    }

    public List<MenuItem> GetFilteredMenu()
    {
        // Проходим по всем позициям
        return _config1.Menu.Where(menuItem => 
        {
            // Ищем рецепт для этого пункта меню
            var recipe = _config1.Recipes.ContainsKey(menuItem.RecipeName) ? _config1.Recipes[menuItem.RecipeName] : 
                null;
            if (recipe == null) return false;

            // Проверяем: есть ли хотя бы один размер, который мы можем приготовить
            return menuItem.Sizes.Any(size => 
            {
                var required = RecipeCalculator.CalculateRequiredIngredients(recipe, size);
                return _inventory.HasEnough(required);
            });
        }).ToList();
    }
    
    public bool CanMake(string recipeName, MenuItem.ServingSize size)
    {
        // Находим рецепт по имени
        var recipe = GetRicepe(recipeName);

        // Считаем, сколько нужно ресурсов на этот объем (через статический калькулятор)
        var required = RecipeCalculator.CalculateRequiredIngredients(recipe, size);

        // Спрашиваем у кладовщика, хватает ли остатков
        return _inventory.HasEnough(required);
    }
    
    public void RefillResource(string name, int amount)
    {
        if (_config1.Resources.ContainsKey(name))
            _config1.Resources[name] += amount;
        else
            _config1.Resources[name] = amount;

        Saving.SaveConfig(_config1);
        Console.WriteLine($"[Refill] {name} пополнено на {amount}");
    }

}
