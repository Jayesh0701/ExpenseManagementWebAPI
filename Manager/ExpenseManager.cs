using Microsoft.IdentityModel.Tokens;
using TestAppAPI.Data;
using TestAppAPI.Interface;
using TestAppAPI.Models;
using TestAppAPI.ViewModel;

namespace TestAppAPI.Manager
{
  public class ExpenseManager : IExpenseManager
  {
    private readonly ExpenseDbContext _expenseDb;
    public ExpenseManager(ExpenseDbContext expenseDb)
    {
      _expenseDb= expenseDb;
    }

    public void CreateExpense(ExpenseViewModel expense)
    {
      if(expense.ExpenseDescription.IsNullOrEmpty())
      {
        throw new ApplicationException("Please provide expense description");
      }
      if(expense.ExpenseDescription.Length<=10)
      {
        throw new ApplicationException("Please provide expense description more than 10 characters");
      }
      if (expense.ExpenseDescription.Length >= 100)
      {
        throw new ApplicationException("Please provide expense description less than 100 characters");
      }
      if(expense.ExpenseAmount==0)
      {
        throw new ApplicationException("Expense amount should not be 0");
      }
      if(expense.ExpenseCategory.IsNullOrEmpty())
      {
        throw new ApplicationException("Please provide Expense Category");
      }
      if(expense.ExpenseCategory.Length<=3)
      {
        throw new ApplicationException("Please provide expense description more than 3 characters");
      }
      ExpenseModel expenseToAdded = new ExpenseModel
      {
        ExpenseDescription= expense.ExpenseDescription,
        ExpenseAmount= expense.ExpenseAmount,
        ExpenseCategory=expense.ExpenseCategory,
        ExpenseDate=expense.ExpenseDate
      };
      _expenseDb.Add(expenseToAdded);
      _expenseDb.SaveChanges();
    }

    public void DeleteExpense(int expenseId)
    {
      if(!IsExpenseExists(expenseId))
      {
        throw new ApplicationException("Expense not found");
      }
      var expenseDetail = _expenseDb.CoreExpenseDetails.Where(item => item.Id == expenseId).FirstOrDefault();
      _expenseDb.CoreExpenseDetails.Remove(expenseDetail);
      _expenseDb.SaveChanges();
    }

    public List<ExpenseModel> GetAllExpenses()
    {
      return _expenseDb.CoreExpenseDetails.ToList();
    }

    public void UpdateExpense(ExpenseModel expense)
    {
      if(!IsExpenseExists(expense.Id))
      {
        throw new ApplicationException("Expense not found");
      }
      var expenseDetail = _expenseDb.CoreExpenseDetails.Where(item => item.Id == expense.Id).FirstOrDefault();
      if (expense.ExpenseDescription.IsNullOrEmpty())
      {
        throw new ApplicationException("Please provide expense description");
      }
      if (expense.ExpenseDescription.Length <= 10)
      {
        throw new ApplicationException("Please provide expense description more than 10 characters");
      }
      if (expense.ExpenseDescription.Length >= 100)
      {
        throw new ApplicationException("Please provide expense description less than 100 characters");
      }
      if (expense.ExpenseAmount == 0)
      {
        throw new ApplicationException("Expense amount should not be 0");
      }
      if (expense.ExpenseCategory.IsNullOrEmpty())
      {
        throw new ApplicationException("Please provide Expense Category");
      }
      if (expense.ExpenseCategory.Length <= 3)
      {
        throw new ApplicationException("Please provide expense description more than 3 characters");
      }

      expenseDetail.ExpenseDescription=expense.ExpenseDescription;
      expenseDetail.ExpenseDate=expense.ExpenseDate;
      expenseDetail.ExpenseCategory=expense.ExpenseCategory;
      expenseDetail.ExpenseAmount=expense.ExpenseAmount;
      _expenseDb.SaveChanges();
    }

    private bool IsExpenseExists(int Id)
    {
      return _expenseDb.CoreExpenseDetails.Any(item => item.Id == Id);
    }
  }
}
