namespace DotaParser52;

using System;
using System.Collections.Generic;
using System.IO;

public class Reader
{
    public string FileName  = @"C:\Users\Пользователь\RiderProjects\DotaParser52\DotaParser52\DataBase.txt";
    public List<string[]> Data = new List<string[]>();
    public void Read()
    {
        string[] Lines = File.ReadAllLines(FileName);
        foreach (string line in Lines)
        {
            string[] values = line.Split(';');
            Data.Add(values);
            
        }
    }
}