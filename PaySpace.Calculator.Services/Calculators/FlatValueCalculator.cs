namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class FlatValueCalculator(IEnumerable<(decimal, decimal, decimal)> settings) : IFlatValueCalculator
  {
    public decimal CalculateTax(decimal annualIncome, int calculatorType)
    {
      if (!settings?.Any() ?? false)
      {
        return decimal.Zero;
      }

      var taxDetails = CalculateTaxDetailsFlatValue(settings, annualIncome);

      return taxDetails;
    }

    public decimal CalculateTaxDetailsFlatValue(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome)
    {
      var taxValue = 0m;

      foreach (var (from, to, rate) in settings)
      {
        if (annualIncome < from || annualIncome > to)
        {
          continue;
        }

        return rate == 10000 ? rate : (annualIncome * rate) / 100;
      }

      return taxValue;
    }
  }
}