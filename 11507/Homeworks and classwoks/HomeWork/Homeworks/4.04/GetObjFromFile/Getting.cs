using System.Text.Json;
using HomeWork.Homeworks._4._04.Config;

namespace HomeWork.Homeworks._4._04.GetObjFromFile;

public  class Getting
{
    public static Config1 LoadConfig()
    {
        try
        {
            // Используем Path.Combine для надежности
            var path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
        
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл конфигурации не найден по адресу: {path}");
            }

            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<Config1>(json);
            if (config != null) 
            {
                Console.WriteLine($"ВНУТРИ LoadConfig: Ресурсов найдено = {config.Resources?.Count ?? -1}");
            }
            return config;
            
            return config ?? throw new InvalidDataException("Файл конфига пуст или поврежден.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при загрузке конфига: {e.Message}");
            throw;
        }
    }
}