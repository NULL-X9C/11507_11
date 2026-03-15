using System.Collections.ObjectModel;

namespace DotaParser52.Homeworks._14._03;

public interface ISubscriber
{
    public void OnAlarm(string mes, DateTime dt);
}

public class Siren 
{
    // private string mes;
    //
    // public Siren(string mes)
    // {
    //     this.mes = mes;
    // }

    public void OnAlarm(string mes, DateTime dt)
    {
        Console.WriteLine("ВКЛЮЧЕНА СИРЕНА: {0}", mes);
    }
}

public class Logger
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