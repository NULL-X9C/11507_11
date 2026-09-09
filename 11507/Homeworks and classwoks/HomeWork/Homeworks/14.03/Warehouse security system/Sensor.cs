namespace HomeWork.Homeworks._14._03;

public class Sensor
{
    public event Action<string, DateTime>? OnAlert;

    public void Trigger(string mesage)
    {
        OnAlert?.Invoke(mesage, DateTime.Now);
    }
}
