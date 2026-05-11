using DotaParser52.Homeworks._4._04.Config;

namespace DotaParser52.Homeworks._4._04.Orders;

public class UserOrder
{
    public string RecipeName { get; init; }

    public MenuItem.ServingSize ServingSize { get; init; }

    public decimal Price { get; init; }

    public DateTime OrderedAt { get; init; } = DateTime.Now;

    public UserOrder(string recipeName, MenuItem.ServingSize servingSize)
    {
        RecipeName = recipeName;
        ServingSize = servingSize;
        Price = servingSize.Price;
    }

    override public string ToString()
    {
        return ($" Заказ [{OrderedAt:MM/dd/yyyy}], {RecipeName}," +
                          $"({ServingSize.Label}) - {Price} денег ");
    }
}
