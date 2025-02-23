namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class ProgressiveCalculator(ICalculatorService calculatorService) : IProgressiveCalculator
  {
    public async Task<decimal> CalculateTax(decimal annualIncome, int calculatorType)
    {
      var settings = await calculatorService.GetCalculatorSettingByCalculatorType(calculatorType);

      if (!settings?.Any() ?? false)
      {
        return decimal.Zero;
      }

      var taxDetails = calculatorService.CalculateTaxDetailsProgressive(settings, annualIncome);

      return taxDetails;
    }
  }
}