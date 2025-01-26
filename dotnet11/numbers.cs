using System.Numerics;
class NumberExperiments
{
  public static void AddAllValues()
  {
    var ints = new int[] { 1, 2, 3, 4 };
    var sum = ints.Sum();
    Console.WriteLine($"Sum = {sum}");
    Console.WriteLine($"Sum = {AddAllValuesGeneric(ints)}");
  }

  private static T AddAllValuesGeneric<T>(T[] values) where T : INumber<T>
  {
    T result = T.Zero;
    foreach (var v in values)
    {
      result += v;
    }
    return result;
  }

  public static void ProcessNumbers()
  {
    // See https://aka.ms/new-console-template for more information


    Console.WriteLine("Hello, World!");
    INumber<int> number = 123;
    Console.WriteLine("num = {0}", number);
    INumber<double> d = 123.45;
    Console.WriteLine("double = {0}", d);
    INumber<int>? n = default;
    Console.WriteLine("n default = '{0}'", n);
    int in_t = default;
    Console.WriteLine("in_t default = {0}", in_t);
  }
}
