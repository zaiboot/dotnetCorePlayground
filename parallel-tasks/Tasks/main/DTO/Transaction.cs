namespace Main.DTO;
public class Transaction
{
  public int TransactionId { get; set; }
  public double Tax { get; set; }
  public double Debit  { get; set; }

  public double Total => Tax + Debit;
}