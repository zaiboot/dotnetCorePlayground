using System.Data;
using Npgsql;

namespace DAL.Repo;

public class Repository
{
  private const string SQL = "SELECT c.id, c.username, t.trx_id, t.debit, t.tax FROM customer c INNER JOIN transactions t ON c.id = t.user_id";

  public async Task ReadSequentialAsync(CancellationToken token, Action<IDataReader> action)
  {

    var connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=postgres";
    using var conn = new NpgsqlConnection(connectionString);
    await conn.OpenAsync(token);
    var cmd = new NpgsqlCommand(SQL, conn);
    var reader = await cmd.ExecuteReaderAsync(token);

    while (await reader.ReadAsync(token))
    {
      action(reader);
    }

  }

  public async Task ReadWithTasksAsync(CancellationToken token, Action<IDataReader> action)
  {

    var connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=postgres";
    using var conn = new NpgsqlConnection(connectionString);
    await conn.OpenAsync(token);
    var cmd = new NpgsqlCommand(SQL, conn);
    var reader = await cmd.ExecuteReaderAsync(token);

    var tasks = new List<Task>();
    while (await reader.ReadAsync(token))
    {
      tasks.Add(Task.Run(() => { action(reader); }, token));
    }

    Task.WaitAll(tasks.ToArray(), token);
  }
}