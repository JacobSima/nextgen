namespace PaySpace.Calculator.Data
{
  using Microsoft.EntityFrameworkCore;

  public class CalculatorContext(DbContextOptions<CalculatorContext> options) : DbContext(options)
  {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
  }
}