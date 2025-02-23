namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class FlatRateCalculator(ICalculatorService calculatorService) : IFlatRateCalculator
  {
    public async Task<decimal> CalculateTax(decimal annualIncome, int calculatorType)
    {
      var settings = await calculatorService.GetCalculatorSettingByCalculatorType(calculatorType);

      if (!settings?.Any() ?? false)
      {
        return decimal.Zero;
      }

      var taxDetails = calculatorService.CalculateTaxDetailsFlatRate(settings, annualIncome);

      return taxDetails;
    }
  }
}