namespace DotaParser52.Homeworks._7._03;

public class DotaParserProcessor
{
    public static void Process()
    {
        Reader reader = new Reader(); 
        reader.Read();
        var start = new Client();
        var filter = new Filter(reader.Data);
        var sequence = filter.Filtering(start.UserOrder());
        foreach (var item in sequence)
            Console.WriteLine(item);
        
    }
   
}