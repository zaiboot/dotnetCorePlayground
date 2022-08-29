using System.Data;

public static class IDataReaderExtensions
{
  public static T Get<T>(this IDataReader reader, string name)
    where T : struct
  {
    var index = reader.GetOrdinal(name);
    var result = (T)reader[index];
    return result;
  }

  public static T GetClass<T>(this IDataReader reader, string name)
  where T : class
  {
    var index = reader.GetOrdinal(name);
    var result = (T)reader[index];
    return result;
  }
}