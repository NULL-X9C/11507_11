namespace HomeWork.Homeworks._14._03.level_1_to_level_4;

public delegate void LongHandler(string s);

public class OrderProcessor (string name)
{
    private readonly string? _name = name;
    public LongHandler Handler;
    
    public void Process()
    {
        // if (_name is { Length: > 0 })
        if(!string.IsNullOrWhiteSpace(_name))
        {
            Handler($"Заказ {_name} принят Платеж прошел");
            Handler($"Заказ {_name} принят Платеж прошел");
            Handler($"Заказ {_name} принят Платеж прошел");
            Handler($"Заказ {_name} принят Платеж прошел");
        }
        else Handler("[ERROR] имя пустое");
    }
}