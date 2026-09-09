namespace HomeWork.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;

public class InventoryService
{
    private readonly Dictionary<string, int> _resources;

    public InventoryService(Dictionary<string, int> resources) => _resources = resources;

    public bool HasEnough(Dictionary<string, int> required)
    {
        return required.All(r => _resources.ContainsKey(r.Key) && _resources[r.Key] >= r.Value);
    }

    public Dictionary<string, int> Consume(Dictionary<string, int> required)
    {
        foreach (var item in required)
        {
            _resources[item.Key] -= item.Value;
        }
        return _resources;
    }
}
