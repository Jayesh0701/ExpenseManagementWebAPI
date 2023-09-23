using Microsoft.EntityFrameworkCore;
using TestAppAPI.Models;

namespace TestAppAPI.Data
{
  public class ExpenseDbContext : DbContext
  {
    public ExpenseDbContext(DbContextOptions options): base (options)
    {
    }

    public DbSet<ExpenseModel> CoreExpenseDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ExpenseModel>()
          .Property(e => e.Id)
          .UseIdentityColumn(); // This will generate an incremental ID for the entity
    }
  }
}
