namespace PaySpace.Calculator.Data
{
  using Microsoft.EntityFrameworkCore;
  using PaySpace.Calculator.Data.Models;

  public class CalculatorContext(DbContextOptions<CalculatorContext> options) : DbContext(options)
  {
    public DbSet<CalculatorHistory> CalculatorHistories { get; set; }
    public DbSet<CalculatorSetting> CalculatorSettings { get; set; }
    public DbSet<PostalCode> PostalCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
  }
}