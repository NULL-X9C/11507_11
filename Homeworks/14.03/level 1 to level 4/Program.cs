namespace DotaParser52.Homeworks._14._03.level_1_to_level_4;

public class Program
{
    public static void Start()
    {// 1
        OrderProcessor processor = new OrderProcessor("    ");
        
        processor.Handler = LogNormal;
        processor.Handler += LogRed;

        processor.Process();
        
        //2
        var employees = new List<Employee>()
        {
            new Employee()
            {
                FirstName = "bob",
                LastName = "Bob",
                Email = "Email",
                Experience = 6,
                Salary = 2500000

            },
            new Employee()
            {
                FirstName = "Rick",
                Email = "Email",
                Experience = 4,
                Salary = 25000

            }
        };
        var dataFilter = new DataFiltering();
        var enumerable = dataFilter.Filter(employees,
            e => e.Experience > 5, employee => employee.Salary > 50000);
        foreach (var employee in enumerable)
        {
            Console.WriteLine(employee.FirstName + " " + employee.LastName);
        }
        
        
        //3
        var user = new User("nnn", "Pro100Pro228", new List<string> { "67" }, 8);

        Action<User> act = ChainOfNotify.SendEmail;
        act += ChainOfNotify.SaveData;
        act += ChainOfNotify.UpdateCounters;
        ChainOfNotify.SafeChain(act,  user);
        
        //4
        List<string> names = new List<string> { "Иван", "Ваня", "Вася" };
        names.ForEachWithIndex((name, index) => Console.WriteLine($"{index + 1}. {name}"));
    }

    static void LogNormal(string message)
    {
        if (!message.Contains("[ERROR]"))
        {
            Console.WriteLine(message);
        }
    }
    
    static void LogRed(string message)
    {
        if (message.Contains("[ERROR]"))
        {
            var cur = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = cur;
        }

    }
}