namespace HomeWork.Homeworks._14._03;

public class LogAnalyzer<T>
{
    public void AnalyzeLog(IEnumerable<T> log, Predicate<T> filter)
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