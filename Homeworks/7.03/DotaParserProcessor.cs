namespace DotaParser52;

public class DotaParserProcessor
{
    public void Process()
    {
        Reader reader = new Reader(); 
        reader.Read();
        var start = new Client();
        var filter = new Filter(reader.Data);
        filter.Filtering(start.UserOrder());
    }
   
}