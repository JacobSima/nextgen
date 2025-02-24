namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class ProgressiveCalculator(IEnumerable<(decimal, decimal, decimal)> settings) : IProgressiveCalculator
  {
    public decimal CalculateTax(decimal annualIncome)
    {
      if (!settings?.Any() ?? false)
      {
        return decimal.Zero;
      }

      var taxDetails = CalculateTaxDetailsProgressive(settings, annualIncome);

      return taxDetails;
    }

    public decimal CalculateTaxDetailsProgressive(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome)
    {
      var taxValue = 0m;

      foreach (var (from, to, rate) in settings)
      {
        if (annualIncome > from)
        {
          var upperLimit = to == null ? annualIncome : to;
          var taxableAmount = Math.Min(annualIncome, upperLimit) - from;

          if (taxableAmount > 0)
          {
            var taxForBracket = (taxableAmount * rate) / 100;
            taxValue += taxForBracket;
          }

          if (annualIncome <= upperLimit)
          {
            break;
          }
        }
      }

      taxValue = Math.Round(taxValue, 2);
      return taxValue;
    }
  }
}