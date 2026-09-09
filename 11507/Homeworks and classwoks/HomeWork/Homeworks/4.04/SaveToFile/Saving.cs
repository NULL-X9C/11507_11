using System.Text.Json;
using HomeWork.Homeworks._4._04.Config;

namespace HomeWork.Homeworks._4._04.SaveToFile;

public class Saving
{
    private readonly string _filePath;
    public Saving(string fileName)
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
    }
    public void Save(string json)
    {
        File.WriteAllText(_filePath, json);
    }

    public static void SaveConfig(Config1 config1)
    {
        var content = JsonSerializer.Serialize(config1, new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        });
        var path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
        File.WriteAllText(path, content);
    }
}