namespace PaySpace.Calculator.Services.Abstractions
{
  using PaySpace.Calculator.Data.Abstractions;

  public interface ITaxCalculatorFactory
  {
    ITaxCalculator? CreateCalculator(int calculatorType, ICalculatorService calculatorService);
  }
}
