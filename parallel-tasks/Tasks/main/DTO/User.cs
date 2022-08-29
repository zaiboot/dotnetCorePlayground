namespace Main.DTO;

public class User
{
  private readonly Dictionary<int, Transaction> _transactions = new();
  private readonly HashSet<int> _txIds = new();
  public string Username { get; }

  public User(string username)
  {
    Username = username;
  }

  public void AddTransaction(int txid, double debit, double tax)
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