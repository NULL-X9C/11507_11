namespace DotaParser52.Homeworks._7._03;

public class Reader
{
    public readonly string FileName  = @"C:\Users\Пользователь\RiderProjects\DotaParser52\DotaParser52\Homeworks\7.03\DataBase.txt";
    public List<string[]> Data = new List<string[]>();
    public void Read()
    {
        string[] lines = File.ReadAllLines(FileName);
        foreach (string line in lines)
        {
            string[] values = line.Split(';');
            Data.Add(values);
            
        }
    }
}