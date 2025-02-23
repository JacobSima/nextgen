namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class TaxCalculatorFactory : ITaxCalculatorFactory
  {
    public ITaxCalculator? CreateCalculator(int calculatorType, ICalculatorService calculatorService)
    {
      return calculatorType switch
      {
        0 => new ProgressiveCalculator(calculatorService),
        1 => new FlatValueCalculator(calculatorService),
        2 => new FlatRateCalculator(calculatorService),
        _ => null
      };
    }
  }
}
