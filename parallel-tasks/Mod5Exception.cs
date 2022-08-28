//We will be simulating reading from kafka, with 4 partitions and try to handle errors
// just for kicks. This is in no way PROD code, but a POC on how to use concurrency using
// tasks (async,await)
using System.Runtime.Serialization;

[Serializable]
class Mod5Exception : Exception
{
    public int P { get; }

  public Mod5Exception() : this(0)
  {
  }

  public Mod5Exception(int p)
  {
    this.P = p;
  }

  public Mod5Exception(string? message) : base(message)
  {
  }

  public Mod5Exception(string? message, Exception? innerException) : base(message, innerException)
  {
  }

  protected Mod5Exception(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }


}