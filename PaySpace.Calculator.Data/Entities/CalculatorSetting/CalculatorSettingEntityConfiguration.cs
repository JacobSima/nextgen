namespace PaySpace.Calculator.Data.Common.CalculatorType
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  internal class CalculatorSettingEntityConfiguration : IEntityTypeConfiguration<CalculatorSetting>
  {
    public void Configure(EntityTypeBuilder<CalculatorSetting> builder)
    {
      builder
        .ToTable("CalculatorSetting");

      builder
        .HasData(GetCalculatorSettings());
    }

    internal static IEnumerable<CalculatorSetting> GetCalculatorSettings()
    {
      return
      [
        new() { Id = 1, Calculator = CalculatorType.Progressive, RateType = RateType.Percentage, Rate = 10, From = 0, To = 8250 },
        new() { Id = 2, Calculator = CalculatorType.Progressive, RateType = RateType.Percentage, Rate = 15, From = 8350, To = 33950 },
        new() { Id = 3, Calculator = CalculatorType.Progressive, RateType = RateType.Percentage, Rate = 25, From = 33950, To = 82250 },
        new() { Id = 4, Calculator = CalculatorType.Progressive, RateType = RateType.Percentage, Rate = 28, From = 82250, To = 171550 },
        new() { Id = 5, Calculator = CalculatorType.Progressive, RateType = RateType.Percentage, Rate = 33, From = 171550, To = 372950 },
        new() { Id = 6, Calculator = CalculatorType.Progressive, RateType = RateType.Percentage, Rate = 35, From = 372950, To = null },

        new() { Id = 7, Calculator = CalculatorType.FlatValue, RateType = RateType.Percentage, Rate = 5, From = 0, To = 199999 },
        new() { Id = 8, Calculator = CalculatorType.FlatValue, RateType = RateType.Amount, Rate = 10000, From = 200000, To = null },

        new() { Id = 9, Calculator = CalculatorType.FlatRate, RateType = RateType.Percentage, Rate = 17.5M, From = 0, To = null },
      ];
    }
  }
}
