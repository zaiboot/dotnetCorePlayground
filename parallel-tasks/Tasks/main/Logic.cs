using System.Data;
using Main.DTO;

namespace Main.BLL;
public class Logic
{
  private static readonly Root r = new();

  public static void PrintSingleRow(IDataReader reader)
  {
    for (int i = 0; i < reader.FieldCount; i++)
    {
      var name = reader.GetName(i);
      var value = reader[i];
      Console.WriteLine("{0} -> {1} ", name, value);
    }
  }

  public static void BuildRootSingleRow(IDataReader reader){
    var userId = reader.Get<string>("id");
    var username = reader.Get<string>("username");
    r.AddUser(userId, username);
  }

}