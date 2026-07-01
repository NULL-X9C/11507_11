using CwSolves2;

var dispatcher = new MyTaskDispatcher();
dispatcher.Fill();

Console.WriteLine($"Starting {dispatcher.Tasks.Count} tasks...");
var sw = System.Diagnostics.Stopwatch.StartNew();

dispatcher.Run();

sw.Stop();
Console.WriteLine($"All tasks completed in {sw.ElapsedMilliseconds} ms");