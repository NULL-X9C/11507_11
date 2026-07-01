namespace SobesSolwesTasks;

public class CountDownTimer
{
    private int _seconds;
    public event EventHandler<TimerEventArgs> Tick;
    public event EventHandler Stopped;

    public async Task Start(int seconds)
    {
        for (_seconds = seconds; _seconds >= 0; _seconds--)
        {
            await Task.Delay(1000);
            Tick?.Invoke(this, new TimerEventArgs()
            {
                SecondsRemaining = _seconds
            });

            if (_seconds == 0)
            {
                Stopped?.Invoke(this, new TimerEventArgs(){SecondsRemaining = 0});
                return;
            }
        }
    }
}