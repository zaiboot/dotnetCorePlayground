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

  public static void BuildRootSingleRow(IDataReader reader)
  {
    var userId = reader.GetClass<string>("id");
    var username = reader.GetClass<string>("username");
    r.AddUser(userId, username);

    var txid = reader.Get<int>("trx_id");
    var debit = reader.Get<double>("debit");
    var tax = reader.Get<double>("tax");
    r.AddTransaction(userId, txid, debit, tax);
  }

}