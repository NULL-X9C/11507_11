using System.Text.Json;
using DotaParser52.Homeworks._4._04.CoffeeMachine.DrinkPreparationLogic;
using DotaParser52.Homeworks._4._04.Orders;
using DotaParser52.Homeworks._4._04.Repots;
using DotaParser52.Homeworks._4._04.Config;

namespace DotaParser52.Homeworks._4._04.CoffeeMachine;

public class EndOfShift
{
    public static void Finish(Config1 myConfig1, DrinkMaster master)
    {
        var history = master.GetHistory();
        
        if (!history.Any())
        {
            history = LoadHistoryFromLog("sales_history.log");
        }

        // 3. Генерируем отчет как обычно
        string jsonReport = ReportingService.GenerateDailyReport(history, myConfig1.Resources);
        File.WriteAllText($"final_report_{DateTime.Now:yyyy-MM-dd}.json", jsonReport);

        // 4. ОЧИСТКА: После того как финальный отчет создан, 
        // файл лога можно удалить или переименовать, чтобы завтра начать с чистого листа.
      //  File.Delete("sales_history.log");

    }

    private static List<UserOrder?> LoadHistoryFromLog(string filePath)
    {
        if (!File.Exists(filePath)) return new List<UserOrder>();

        var lines = File.ReadAllLines(filePath);
    
        // Превращаем каждую строку обратно в объект UserOrder
        return lines
            .Select(line => JsonSerializer.Deserialize<UserOrder>(line))
            .Where(order => order != null)
            .ToList();
    }

}