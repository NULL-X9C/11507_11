namespace CwSolves;

public class ControlWorkProcessor
{
    public void RunTask1()
    {
        var rez = MathUtils.FindMedian<int>(2, 1, 4);
        int[] myar = [1, 5, 7, 4, 3, 2];
        Console.WriteLine(rez);
        var rez2 = MathUtils.FindArrayMedian<int>(myar);
        Console.WriteLine(rez2);
    }

    public void RunTask2()
    {
        var monitor = new FinancialMonitor()
        {
            WarningLimit = 10000
        };
        monitor.LargeTransactionDetected += (s, e) =>
        {
            Console.WriteLine($"ТРЕВОГА! Крупный перевод: [{e.Amount}] (Лимит: [{e.Limit}]) в [{e.Time}]");
        };
        monitor.ProcessTransfer(12122);
        monitor.ProcessTransfer(121);
        monitor.ProcessTransfer(10001);
    }
}