using System;
using System.Diagnostics;
using System.IO;

namespace DotaParser52.Homeworks._11._04;

public class BigDataAnalyze
{
    public void StartAnalyze()
    {
        const string filePath = "bigdata.txt";
        const byte targetByte = 65; 
        
        byte[] buffer = new byte[65536];
        long count = 0;

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден. Сначала сгенерируйте его.");
            return;
        }

        var stopwatch = Stopwatch.StartNew();
        
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read,
                   FileShare.Read, bufferSize: 65536, FileOptions.SequentialScan))
        {
            int bytesRead;
            
            while ((bytesRead = fs.Read(buffer, 0, buffer.Length))  > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    if (buffer[i] == targetByte)
                    {
                        count++;
                    }
                }
            }
        }

        stopwatch.Stop();

        Console.WriteLine($"Найдено символов 'A': {count:N0}");
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс ({stopwatch.Elapsed:ss\\.fff} с)");
    }
}