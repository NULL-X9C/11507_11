namespace DotaParser52.Homeworks._14._03;

public class LogAnalazer<T>
{
    public void AnalazeLog(IEnumerable<T> log, Predicate<T> filter)
    {
        bool isFound = false;
        foreach (var logItem in log)
        {
            if (filter(logItem))
            {
                  Console.WriteLine(logItem);
                  isFound = true;
            }
        }
        if (!isFound)
            Console.WriteLine("Ничё не найдено ");
    }

    public void ViewAllLogs(IEnumerable<T> log)
    {
        Console.WriteLine(string.Join(", ", log));
    }
}