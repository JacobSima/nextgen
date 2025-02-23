namespace PaySpace.Calculator.Services.Calculators
{
  using System.Threading.Tasks;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class FlatValueCalculator(ICalculatorService calculatorService) : IFlatValueCalculator
  {
    public async Task<decimal> CalculateTax(decimal annualIncome, int calculatorType)
    {
      var settings = await calculatorService.GetCalculatorSettingByCalculatorType(calculatorType);

      if (!settings?.Any() ?? false)
      {
        return decimal.Zero;
      }

      var taxDetails = calculatorService.CalculateTaxDetailsFlatValue(settings, annualIncome);

      return taxDetails;
    }
  }
}