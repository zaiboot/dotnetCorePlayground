//We will be simulating reading from kafka, with 4 partitions and try to handle errors
// just for kicks. This is in no way PROD code, but a POC on how to use concurrency using
// tasks (async,await)
using Basics;
class ParalleForEachTests
{
  void DoBasicParallelForEachWithErrorHandling(List<int> range)
  {

    var basic = new BasicParallelForEachWithErrorHandling();
    try
    {
      basic.DoWork(range);
    }
    catch (AggregateException ae)
    {
      //We are catching the exception for the index in the range that failed.
      ae.Handle((e) =>
      {
        if (e is Mod5Exception m5)
        {
          Console.WriteLine("Exception Mod5Exception, index = {0}", m5.P);
        }
        else
        {
          Console.WriteLine("Exception {0}", e.Message);
        }
        return true;
      });

    }
  }

  void DoBasicParallelForEach(List<int> range)
  {
    var basic = new BasicParallelForEach();
    basic.DoWork(range);
  }

  void DoBasicParallelForEachWithManualCancellation(List<int> range, CancellationToken token)
  {
    var options = new ParallelOptions
    {
      CancellationToken = token,
    };

    var res = Parallel.ForEach(range, options, (p, state) =>
    {

      if (!state.IsStopped)
      {

        Thread.Sleep(p * 100);// simulate some work depending on the input
        Console.WriteLine(p);// Note the output is in disarray
        if (p % 3 == 0)
        {
          Console.WriteLine("Broken cycle in {0}. Not all of the elements were processed", p);
          state.Stop();
        }
      }
      else
      {
        Console.WriteLine("Refusing to process {0}", p);
      }
    });

    Console.WriteLine($"Finished {nameof(DoBasicParallelForEachWithManualCancellation)}");
  }

  void DoBasicParallelForEachWithCancellation(List<int> range, CancellationToken token)
  {
    var basic = new BasicParallelForEach();

    try
    {
      basic.DoWork(range, token);
    }
    catch (OperationCanceledException oce)
    {
      System.Console.WriteLine("Handled on {0} with message {1}", nameof(DoBasicParallelForEachWithCancellation), oce.Message);
    }
  }

  public void Main()
  {
    var range = Enumerable.Range(1, 10).ToList();

    // ParallelFor falls under the Data Parallelism area. From MSDN
    //Data parallelism refers to scenarios in which the same operation is performed concurrently (that is, in parallel) on elements in a source collection or array. In data parallel operations, the source collection is partitioned so that multiple threads can operate on different segments concurrently.
    DoBasicParallelForEach(range);
    DoBasicParallelForEachWithErrorHandling(range);

    Console.WriteLine("Now using a Cancellation of no more than 1 sec");
    //To cancel ParallelFor, use cancellationToken and paralleloptions
    var sourceWithTimeOut = new CancellationTokenSource(1_000); //Whole task mustn't take more than 1 sec

    sourceWithTimeOut.Token.Register(() =>
      {
        Console.WriteLine("Good good, operation was cancelled handling when the operation was stopped, can help free resources");
        Console.WriteLine("However we do not know how many records were processed, do we care? ");
      });
    var token = sourceWithTimeOut.Token;
    DoBasicParallelForEachWithCancellation(range, token);

    var manualSource = new CancellationTokenSource();
    manualSource.Token.Register(() =>
    {
      Console.WriteLine("This has been cancelled due to manual input.");
    });

    Console.WriteLine("Manual stopping, not due to timeout but when the index %3 == 0");
    range = Enumerable.Range(1, 500).ToList();
    DoBasicParallelForEachWithManualCancellation(range, manualSource.Token);
    Console.WriteLine("Remember: We use partitions here, that's why we need to stop the process 4 times");
    Console.WriteLine("\tThis is calculation on your hardware arch and resources.");
    Console.WriteLine("And remember to always process small collections with TPL parallel.ForEach.");
    Console.WriteLine("For bigger stuffs, look at Tasks, async/await.");
  }

}

