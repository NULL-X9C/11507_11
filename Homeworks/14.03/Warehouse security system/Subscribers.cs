using System.Collections.ObjectModel;

namespace DotaParser52.Homeworks._14._03;

public interface ISubscriber
{
    public void OnAlarm(string mes, DateTime dt);
}

public class Siren : ISubscriber
{
    public void OnAlarm(string mes, DateTime dt)
    {
        Console.WriteLine("ВКЛЮЧЕНА СИРЕНА: {0}", mes);
    }
}

public class Logger : ISubscriber
{
    public ObservableCollection<string> Logs {get; private set;}

    public Logger()
    {
        Logs = new ObservableCollection<string>();
    }
    
    public void OnAlarm(string mes, DateTime dt)
    {
        AddLog(mes, dt);
    }

    public void AddLog(string mes, DateTime dt)
    {
        Logs.Add(mes + $"В  : {dt}");
    }
}