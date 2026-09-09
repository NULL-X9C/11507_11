namespace HomeWork.Homeworks._4._04.CoffeeMachine.Animation;

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
    public static void PlayCoffeeLoading(int durationMs = 4000)
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
        int maxLines = frames.Max(f => f.Split('\n').Length); // Динамическая высота

        for (int i = 0; i < iterations; i++)
        {
            string frame = frames[i % frames.Length];
            string[] lines = frame.Split('\n');
        
            // Рисуем кадр построчно, не сдвигая курсор лишним
            for (int line = 0; line < maxLines; line++)
            {
                Console.SetCursorPosition(0, startTop + line);
                Console.Write(line < lines.Length ? lines[line].PadRight(25) : new string(' ', 25));
            }
        
            Thread.Sleep(frameDelayMs);
        }

        // Корректный выход: переводим курсор ПОСЛЕ области анимации
        Console.SetCursorPosition(0, startTop + maxLines + 1);
    }
}