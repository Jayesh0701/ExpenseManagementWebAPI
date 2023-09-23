using Microsoft.AspNetCore.Mvc;
using TestAppAPI.Interface;
using TestAppAPI.Models;
using TestAppAPI.ViewModel;

namespace TestAppAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExpenseController : ControllerBase
  {
    private readonly IExpenseManager _expenseManager;

    public ExpenseController(IExpenseManager expenseManager)
    {
      _expenseManager= expenseManager;
    }

    [Route("[action]")]
    [HttpGet]
    public IActionResult GetExpenses()
    {
      try
      {
        var allExpenses=_expenseManager.GetAllExpenses();
        return Ok(new { allExpenses });
      }
      catch (Exception ex)
      {
        return BadRequest(new { status = "fail", message = ex.Message });
      }
    }

    [Route("[action]")]
    [HttpPost]
    public IActionResult CreateExpense(ExpenseViewModel expense)
    {
      try
      {
        _expenseManager.CreateExpense(expense);
        return Ok(new {status="Success",message="Record Created Successfully"});
      }
      catch(Exception ex)
      {
        return BadRequest(new {status="fail", message=ex.Message});
      }
    }
    [Route("[action]")]
    [HttpPut]
    public IActionResult UpdateExpense(ExpenseModel expense)
    {
      try
      {
        _expenseManager.UpdateExpense(expense);
        return Ok(new { status = "Success", message = "Record Updated Successfully" });
      }
      catch (Exception ex)
      {
        return BadRequest(new { status = "fail", message = ex.Message });
      }
    }
    [Route("[action]")]
    [HttpDelete]
    public IActionResult DeleteExpense(int expenseId)
    {
      try
      {
        _expenseManager.DeleteExpense(expenseId);
        return Ok(new { status = "Success", message = "Record Deleted Successfully" });
      }
      catch (Exception ex)
      {
        return BadRequest(new { status = "fail", message = ex.Message });
      }
    }
  }
}
