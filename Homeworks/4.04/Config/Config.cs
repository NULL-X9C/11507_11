using DotaParser52.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;

namespace DotaParser52.Homeworks._4._04.Config;

public class Config
{
    public decimal MilkAmount { get;set; }
    public decimal WaterAmount { get; set; }
    public decimal CreamAmount { get; set; }

    public List<Coffee> Menu = new List<Coffee>()
    {
        new Coffee("Latte", 150, 200, 50,
            100, 50, 0),
        
        new Coffee("Raff", 200, 183, 100,
            50, 0, 33),
        
        new Coffee("Milk", 80, 99, 0,
            99, 0, 0),
        
        new Coffee("Espresso", 68, 30, 30,
            0, 0, 0),
        
        new Coffee("Cappuccino", 180, 180, 30,
            120, 0, 30),
        
        new Coffee("Americano", 120, 200, 30, 
            0, 170, 0),
        
        new Coffee("Mocha", 210, 220, 30,
            100, 0, 90),
        
        new Coffee("Flat White", 190, 160, 40, 
            120, 0, 0),
        
        new Coffee("Macchiato", 140, 60, 30, 
            20, 0, 10),
        
        new Coffee("Cortado", 160, 120, 30,
            90, 0, 0),
        
        new Coffee("Iced Latte", 220, 250, 40,
            150, 40, 20)
    };
}