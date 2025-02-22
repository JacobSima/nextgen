namespace PaySpace.Calculator.Data.Entities.PostalCode
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using PaySpace.Calculator.Data.Models;

  internal class PostalCodeEntityConfiguration : IEntityTypeConfiguration<PostalCode>
  {
    public void Configure(EntityTypeBuilder<PostalCode> builder)
    {
      builder
        .ToTable("PostalCode");

      builder
        .HasData(GetPostalCodes());
    }

    private static IEnumerable<PostalCode> GetPostalCodes()
    {
      return
      [
        new() { Id = 1, Calculator = CalculatorType.Progressive, Code = "7441" },
        new() { Id = 2, Calculator = CalculatorType.FlatValue, Code = "A100" },
        new() { Id = 3, Calculator = CalculatorType.FlatRate, Code = "7000" },
        new() { Id = 4, Calculator = CalculatorType.Progressive, Code = "1000" },
      ];
    }
  }
}
