namespace Basics;

public class BasicParallelForEachWithErrorHandling
{
  public void DoWork(IReadOnlyList<int> range)
  {
    Parallel.ForEach(range, (p) =>
   {
     Thread.Sleep(p * 100);// simulate some work depending on the input
     if (p % 2 == 0)
     {
       throw new Mod5Exception(p);
     }
     Console.WriteLine($"No error on {p}");// Note the output is in disarray
   });
  }
}
