using Main.DTO.Exceptions;

namespace Main.DTO;
public class Root
{
  private readonly Dictionary<string, User> _users = new();
  private readonly HashSet<string> _userIds = new();
  public Root()
  {

  }

  public void AddUser(string userId, string username)
  {
    if (_userIds.Contains(userId))
    {
      //ignore
      return;
    }
    _userIds.Add(userId);
    var u = new User(username);
    _users.Add(userId, u);

  }

  public void AddTransaction(string userId, int txid, double debit, double tax)
  {
    if (!_userIds.Contains(userId))
    {
      throw new UserNotFoundException($"{userId} not found");
    }
    _users[userId].AddTransaction(txid, debit, tax);
  }
}
