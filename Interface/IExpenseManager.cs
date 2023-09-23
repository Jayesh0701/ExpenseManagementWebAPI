using TestAppAPI.Models;
using TestAppAPI.ViewModel;

namespace TestAppAPI.Interface
{
  public interface IExpenseManager
  {
    public List<ExpenseModel> GetAllExpenses();
    public void CreateExpense(ExpenseViewModel expense);
    public void UpdateExpense(ExpenseModel expense);
    public void DeleteExpense(int expenseId);
  }
}
