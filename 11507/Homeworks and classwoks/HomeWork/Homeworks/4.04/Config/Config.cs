using HomeWork.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;

namespace HomeWork.Homeworks._4._04.Config;

public class Config1
{
    // остатки ингр-в ч-з сл-ь
    public Dictionary<string, int> Resources { get; set; } = new Dictionary<string, int>()
    {
        // { "CoffeeBeans", 1000 }, // граммы
        // { "Milk", 2000 }, // миллилитры
        // { "Water", 5000 }, // миллилитры
        // { "Cream", 1000 }, // миллилитры
        // { "Chocolate", 500 }, // граммы
        // { "VanillaSyrup", 800 }, // миллилитры
        // { "CaramelSyrup", 800 }, // миллилитры
        // { "Sugar", 2000 }, // граммы
        // { "Cocoa", 300 }, // граммы
        // { "CoconutMilk", 1500 }, // миллилитры
        // { "Cinnamon", 100 } // граммы
    };

    public Dictionary<string, Coffee> Recipes { get; set; } = new();
    // {
    //     { "Капучино", new Coffee("Капучино", 200, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 400 }, // граммы
    //             { "Milk", 150 }, // миллилитры
    //             { "Water", 50 } // миллилитры
    //         })
    //     },
    //     { "Латте", new Coffee("Латте", 300, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 20 },
    //             { "Milk", 250 },
    //             { "Water", 50 }
    //         })
    //     },
    //     { "Американо", new Coffee("Американо", 150, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 18 },
    //             { "Water", 150 }
    //         })
    //     },
    //     { "Эспрессо", new Coffee("Эспрессо", 30, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 15 },
    //             { "Water", 30 }
    //         })
    //     },
    //     { "Флэт Уайт", new Coffee("Флэт Уайт", 150, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 18 },
    //             { "Milk", 120 },
    //             { "Water", 30 }
    //         })
    //     },
    //     { "Раф Кофе", new Coffee("Раф Кофе", 200, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 18 },
    //             {"Water", 150 },
    //             { "Cream", 30 },
    //             { "VanillaSyrup", 20 },
    //             { "Sugar", 10 }
    //         })
    //     },
    //     { "Мокко", new Coffee("Мокко", 170, new Dictionary<string, int>()
    //         {
    //             { "CoffeeBeans", 18 },
    //             { "Milk", 150 },
    //             { "Chocolate", 20 },
    //             { "Sugar", 10 }
    //         })
    //     }
    // };

    public List<MenuItem> Menu { get; set; } = new List<MenuItem>();
    // {
    //     new MenuItem("Капучино")
    //     {
    //         Sizes =
    //         {
    //             new MenuItem.ServingSize("S", 200, 90m),   // 200 мл, 90 руб.
    //             new MenuItem.ServingSize("M", 300, 150m),  // 300 мл, 150 руб.
    //             new MenuItem.ServingSize("L", 400, 200m),  // 400 мл, 200 руб.
    //         }
    //     },
    //     new MenuItem("Латте")
    //     {
    //         Sizes =
    //         {
    //             new ("S", 200, 89m),
    //             new ("M", 300, 150m),
    //             new ("L", 400, 200m),
    //         }
    //     },
    //     new MenuItem("Американо")
    //     {
    //         Sizes =
    //         {
    //             new MenuItem.ServingSize("S", 150, 70m),
    //             new MenuItem.ServingSize("M", 250, 110m),
    //             new MenuItem.ServingSize("L", 350, 140m),
    //         }
    //     },
    //     new MenuItem("Эспрессо")
    //     {
    //         Sizes =
    //         {
    //             // Для эспрессо объем маленький, цена ниже
    //             new MenuItem.ServingSize("Single", 30, 60m),
    //             new MenuItem.ServingSize("Double", 60, 100m),
    //         }
    //     },
    //     new MenuItem("Флэт Уайт")
    //     {
    //         Sizes =
    //         {
    //             new MenuItem.ServingSize("S", 150, 120m),
    //             new MenuItem.ServingSize("M", 250, 180m),
    //         }
    //     },
    //     new MenuItem("Раф Кофе")
    //     {
    //         Sizes =
    //         {
    //             new MenuItem.ServingSize("S", 200, 140m),
    //             new MenuItem.ServingSize("M", 300, 210m),
    //             new MenuItem.ServingSize("L", 400, 270m),
    //         }
    //     },
    //     new MenuItem("Мокко")
    //     {
    //         Sizes =
    //         {
    //             new MenuItem.ServingSize("S", 200, 130m),
    //             new MenuItem.ServingSize("M", 300, 190m),
    //             new MenuItem.ServingSize("L", 400, 240m),
    //         }
    //     }
    // };
}

public class MenuItem
{
    public string? RecipeName { get; set; }
    public List<ServingSize> Sizes { get; set; } = new();
    public MenuItem(){ }
    
    public MenuItem(string recipeName)
    {
        RecipeName = recipeName;
    }
    
    public class ServingSize
    {
        public string? Label { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        
        public ServingSize(){ }

        public ServingSize(string label, int volume, decimal price)
        {
            Label = label;
            Volume = volume;
            Price = price;
        }
    }
}