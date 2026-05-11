using System.Text.Json;
using DotaParser52.Homeworks._4._04.Orders;

namespace DotaParser52.Homeworks._4._04.Repots;

public static class ReportingService
{
    public static string GenerateDailyReport(
        IEnumerable<UserOrder> history, 
        Dictionary<string, int> remainingResources)
    {
        // анонимный объект
        var report = new
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            
            // Секция финансов
            Finance = new {
                TotalRevenue = history.Sum(o => o.Price),
                OrdersCount = history.Count()
            },

            // Статистика по напиткам
            Popularity = history.GroupBy(o => o.RecipeName)
                .Select(g => new {
                    Name = g.Key,
                    Quantity = g.Count(),
                    SubTotal = g.Sum(o => o.Price)
                }),

            // Текущие остатки ресурсов
            StockBalance = remainingResources 
        };

        return JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
    }
}