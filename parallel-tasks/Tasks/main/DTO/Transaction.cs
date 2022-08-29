namespace Main.DTO;
public class Transaction
{
  public string TransactionId { get; set; }
  public decimal Tax { get; set; }
  public decimal Debit  { get; set; }

  public decimal Total => Tax + Debit;
}