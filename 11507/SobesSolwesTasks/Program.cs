using SobesSolwesTasks;
using System;
using System.Threading;
using System.Threading.Tasks;

var timer = new CountDownTimer();
timer.Tick += (sender, args) => Console.WriteLine($"Осталось [{args.SecondsRemaining}] секунд");
timer.Stopped += (sender, eventArgs) => Console.WriteLine("Время вышло! Бум");

await timer.Start(6);
