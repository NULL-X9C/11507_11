namespace CwSolves2;
using System.Threading.Tasks;

// TODO: Напишите TaskDispatcher: 
//создайте список из 50 задач (Action). Запустите их так, чтобы в любой момент времени выполнялось не более 5 задач 
//  (используйте обычный Semaphore(5, 5)).
// fill
//process

public class MyTaskDispatcher
{
    private readonly Semaphore Sem = new Semaphore(5, 5);
    public readonly List<Action> Tasks = new List<Action>();

    public void Fill()
    {
        for (int i = 0; i < 50; i++)
        {
            Tasks.Add(() =>
            {
                Thread.Sleep(100);
            });
        }
    }

    public void Run()
    {
        var taskArray = new Task[50];
        for (int i = 0; i < 50; i++)
        {
            Action action = Tasks[i];
            taskArray[i] = Task.Run(() =>
            {
                Sem.WaitOne();
                try
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    action();
                }
                finally
                {
                    Sem.Release();
                }
            });
        }
        Task.WaitAll(taskArray);
    }
}