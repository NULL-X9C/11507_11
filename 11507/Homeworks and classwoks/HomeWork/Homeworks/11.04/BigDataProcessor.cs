namespace HomeWork.Homeworks._11._04;

public class BigDataProcessor
{
    public void Run()
    {
        var fileCreator = new FileCreater();
        fileCreator.CreateBigFile();
        var dataAnalyze = new BigDataAnalyze();
        dataAnalyze.StartAnalyze();
    }
}