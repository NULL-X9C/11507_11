using System.IO;
using System;
namespace HomeWork.Homeworks._11._04;

public class FileCreater
{
    public void CreateBigFile(string filename = "Bigdata.txt")
    {
        using StreamWriter sw = new StreamWriter(filename);
        for (int i = 0; i < 50_000_000; i++)
        {
            sw.WriteLine("Data line with some A symbols and other chars");
        }
    }
}