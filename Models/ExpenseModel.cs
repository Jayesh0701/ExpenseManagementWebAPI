namespace TestAppAPI.Models
{
  public class ExpenseModel
  {
    public int Id { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? ExpenseDescription { get; set; }
    public int ExpenseAmount { get; set; }
    public string? ExpenseCategory { get; set; }

  }
}
