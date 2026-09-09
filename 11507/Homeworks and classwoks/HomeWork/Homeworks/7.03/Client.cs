using System.Diagnostics;

namespace HomeWork;

public class Client
{
    public (int, int, int) UserOrder()
    {
        Console.WriteLine("Welcome to Dota Parser");
        Console.WriteLine("Доступные хфрактеристики персонажа для сортировки: \n Здоровье | Урон | Ловкость | Сложность");
        Console.WriteLine("Выберете характеристику");
        string? input = Console.ReadLine().Trim().ToLower();
        int parametr = input switch
        {
            "здоровье" => 1,
            "урон" => 2,
            "ловкость" => 3,
            "сложность" => 4,
            _ => throw new Exception("нормальные данны введи ")
        };
        
        Console.WriteLine("Ведите значение характеристики {0}", input);
        string input1 = Console.ReadLine();
        int parametr1;
        if (int.TryParse(input1, out parametr1) == false)
        {
            throw new Exception(" введите число");
        };
        
        
        Console.WriteLine("Вы хотите получить героев с характеристикой равной введённой вами или большей?  введите = или > ");
        string? input2 = Console.ReadLine();
        int parametr2 = input2 switch
        {
            "=" => 0,
            ">" => 1,
            _ => throw new Exception("нормальные данны введите ")
        };
        return (parametr, parametr1, parametr2);
    }
}