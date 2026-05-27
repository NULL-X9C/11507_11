namespace DotaParser52.Homeworks._14._03.level_1_to_level_4;

public class ChainOfNotify
{
    public static void SendEmail(User user)
    {
        if(user.FavoriteMemes.Any(m =>
               m.Contains("67") ||
               m.Contains("Six Seven", StringComparison.OrdinalIgnoreCase) ||
               m.Contains("SixSeven", StringComparison.OrdinalIgnoreCase) ||
               m.Contains("6-7", StringComparison.OrdinalIgnoreCase) || 
               m.Contains("6 7", StringComparison.OrdinalIgnoreCase)))
           throw new Exception("Регистрация доступна только лицам 18+");
        
        Console.WriteLine("Отправлен код регистрации для {0} : {1}", user.Name, user.Email);
    }

    public static void SaveData(User user)
    {
        if (user.Age > 122) throw new InvalidDataException("Слишком большой возраст");
        Console.WriteLine("Данные сохранены");
    }

    public static void UpdateCounters(User user)
    {
        Random random = new Random();
        if (random.Next(3) == 0) throw new Exception("ПРоблема с обеовлением счётчиков");
        Console.WriteLine("Счётчики обновлены");
    }

    public static void SafeChain(Action<User> action, User user)
    {
        
        foreach (var del in action.GetInvocationList())
        {
            try
            {
                //  (del as Action<User>)?.Invoke(user);
          
                ((Action<User>)del)?.Invoke(user);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[ERROR] {e.Message}");
                //  throw;
            }
        }
        
    }
}

public record User(string Email, string Name, List<string> FavoriteMemes, int Age);