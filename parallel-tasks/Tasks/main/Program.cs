// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using DAL.Repo;
using Main.BLL;

var repo = new Repository();
var manualSource = new CancellationTokenSource();
manualSource.Token.Register(() =>
{
  Console.WriteLine("This has been cancelled due to manual input.");
});

var stopWatch = new Stopwatch();
Console.WriteLine("Starting watch sequential ");
stopWatch.Start();
await repo.ReadSequentialAsync(manualSource.Token, Logic.BuildRootSingleRow);
stopWatch.Stop();
Console.WriteLine("Time spend sequential: {0:c}", stopWatch.Elapsed);

// Console.WriteLine("Starting watch Tasks");
// stopWatch.Reset();
// stopWatch.Start();
// await repo.ReadSequentialAsync(manualSource.Token, Logic.PrintSingleRow);

// stopWatch.Stop();
// Console.WriteLine("Time spend Tasks: {0:c}", stopWatch.Elapsed);

