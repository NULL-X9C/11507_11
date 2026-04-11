namespace DotaParser52.Homeworks;

public class TransactionEventArgs : EventArgs
{
    public decimal Amount { get; set; }
    public decimal Limit { get; set; }
    public DateTime Time { get; set; }
}

public class FinancialMonitor
{
    public decimal WarningLimit { get; set; } = 50000;
    public event EventHandler<TransactionEventArgs> LargeTransactionDetected;

    public void ProcessTransfer(decimal amount)
    {
        Console.WriteLine("Начинаю перевод...");
        if (amount > WarningLimit)
        {
            LargeTransactionDetected?.Invoke(this, new TransactionEventArgs()
                { Amount = amount , Time = DateTime.Now, Limit = WarningLimit});
        }
        else
        {
            Console.WriteLine("успешно");
        }
    }
}