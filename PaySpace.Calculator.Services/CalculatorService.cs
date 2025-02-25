namespace PaySpace.Calculator.Services
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class CalculatorService(ITaxCalculatorFactory taxCalculatorFactory) : ICalculatorService
  {
    public async Task<ITaxCalculator> GetCalculator(int calculatorType)
    {
      var calculator = await taxCalculatorFactory.CreateCalculator(calculatorType);

      return calculator;
    }

  }
}
