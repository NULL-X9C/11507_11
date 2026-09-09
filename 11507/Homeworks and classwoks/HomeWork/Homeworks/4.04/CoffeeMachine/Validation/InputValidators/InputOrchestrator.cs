namespace HomeWork.Homeworks._4._04.CoffeeMachine.Validation.InputValidators;

public class InputOrchestrator
{
    public static T ReadUntilValid<T>(Func<T> getInput, Func<T, bool> isValid, string errorMsg)
    {
        while (true)
        {
            try
            {
                T value = getInput();
                if (isValid(value)) return value;
            }
            catch { } // Защита от краша при кривом парсинге/вводе
            Console.WriteLine(errorMsg);
        }
    }
}