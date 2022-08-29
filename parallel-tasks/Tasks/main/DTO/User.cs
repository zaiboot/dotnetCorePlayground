namespace Main.DTO;

public class User
{
  private readonly Dictionary<string, Transaction> _transactions = new();
  private readonly HashSet<string> _txIds = new();
  public string Username { get; }

  public User(string username)
  {
    Username = username;
  }

  public void AddTransaction(string txid, decimal debit, decimal tax)
  {
    if (_txIds.Contains(txid))
    {
      Console.WriteLine("{0} already added, ignoring");
      return;
    }

    var t = new Transaction
    {
      Tax = tax,
      Debit = debit,
      TransactionId = txid
    };
    _transactions.Add(txid, t);
  }


}