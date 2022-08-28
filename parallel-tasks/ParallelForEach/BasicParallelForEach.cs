namespace Basics;

public class BasicParallelForEach
{
  public void DoWork(IReadOnlyList<int> range, CancellationToken token = default)
  {
    var options = new ParallelOptions
    {
      CancellationToken = token,

    };
    Parallel.ForEach(range, options, (p) =>
    {
      Thread.Sleep(p * 100);// simulate some work depending on the input
      Console.WriteLine(p);// Note the output is in disarray
    });
    Console.WriteLine($"Finished {nameof(BasicParallelForEach)}");
  }
}