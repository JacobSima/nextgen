namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class FlatRateCalculator(IEnumerable<(decimal, decimal, decimal)> settings) : IFlatRateCalculator
  {
    public decimal CalculateTax(decimal annualIncome, int calculatorType)
    {
      if (!settings?.Any() ?? false)
      {
        return decimal.Zero;
      }

      var taxDetails = CalculateTaxDetailsFlatRate(settings, annualIncome);

      return taxDetails;
    }

    public decimal CalculateTaxDetailsFlatRate(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome)
    {
      var taxValue = 0m;

      foreach (var (from, to, rate) in settings)
      {
        if (annualIncome < from || annualIncome > to)
        {
          continue;
        }

        return (annualIncome * rate) / 100;
      }

      return taxValue;
    }
  }
}