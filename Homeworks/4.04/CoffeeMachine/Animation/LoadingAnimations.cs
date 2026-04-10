namespace DotaParser52.Homeworks._4._04.CoffeeMachine.Animation;

public static class LoadingAnimations
{
    // ☕ КОФЕ: чашка наполняется, пар поднимается
    private static readonly string[] CoffeeFrames = new string[]
    {
        "    ~  ~    \n   \\    /   \n    \\__/    \n    |  |    \n    |  |    \n    ----    ",
        "   ~ ~ ~    \n  \\      /  \n   \\____/   \n   |    |   \n   |~~  |   \n   ------   ",
        "    ~ ~     \n   \\    /   \n    \\__/    \n    |~~|    \n    |~~|    \n    ----    ",
        "   ~ ~ ~    \n  \\      /  \n   \\____/   \n   |~~~~|   \n   |~~~~|   \n   ------   "
    };

    // 🪳 ТАРАКАН-МЕМ: раскачивается и перебирает лапками (классический "диско-таракан")
    private static readonly string[] RoachFrames = new string[]
    {
        "    \\_/     \n   (o o)    \n  --|   |-- \n    | |     \n   /   \\    \n            ",
        "     \\      \n    (o o)   \n   --|   |-- \n    / \\     \n   /   \\    \n            ",
        "    /_/     \n   (o o)    \n  --|   |-- \n    | |     \n   \\   /    \n            "
    };

    /// <summary>
    /// Запускает кофейную анимацию загрузки
    /// </summary>
    public static void PlayCoffeeLoading(int durationMs = 3000)
    {
        PlayAnimation(CoffeeFrames, durationMs, frameDelayMs: 150);
    }

    /// <summary>
    /// Запускает мемную анимацию с танцующим тараканом
    /// </summary>
    public static void PlayRoachLoading(int durationMs = 3000)
    {
        PlayAnimation(RoachFrames, durationMs, frameDelayMs: 120);
    }

    // Внутренний движок анимации
    private static void PlayAnimation(string[] frames, int totalDelayMs, int frameDelayMs)
    {
        int startTop = Console.CursorTop;
        int iterations = totalDelayMs / frameDelayMs;
        int maxLines = frames[0].Split('\n').Length;
        int maxLen = 20; // Ширина области анимации (подобрана под кадры)

        for (int i = 0; i < iterations; i++)
        {
            // Возвращаем курсор в начало области анимации
            Console.SetCursorPosition(0, startTop);
            
            // Очищаем область от предыдущего кадра (защита от артефактов)
            for (int line = 0; line < maxLines; line++)
            {
                Console.WriteLine(new string(' ', maxLen));
            }
            Console.SetCursorPosition(0, startTop);

            // Рисуем текущий кадр
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(frameDelayMs);
        }

        // Сдвигаем курсор под анимацию, чтобы следующий вывод не наложился
        Console.SetCursorPosition(0, startTop + maxLines);
        Console.WriteLine();
    }
}