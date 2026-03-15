namespace DotaParser52.Homeworks._14._03;

public class SensorProcessor
{
    public void Process()
    {
        Sensor sensor = new Sensor();
        var dateTime = DateTime.Now;
        var siren = new Siren();
        var logger = new Logger();

        sensor.OnAlert += siren.OnAlarm;
        sensor.OnAlert += logger.AddLog;

        logger.Logs.CollectionChanged += (s, e) =>
        {
            Console.WriteLine("Запись добавлена в БД");
        };
        
        sensor.Trigger("Критично: надвигается цунами ");
        sensor.Trigger("проверка связи");
        
        var logFilt = new LogFilter("Критично");
        var logAnalyzer = new LogAnalyzer<string>();
        logAnalyzer.AnalyzeLog(logger.Logs, logFilt.Filter);
    }
}