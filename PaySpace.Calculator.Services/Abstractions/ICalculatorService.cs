namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Services.Abstractions;

  public interface ICalculatorService
  {
    Task<ITaxCalculator> GetCalculator(int calculatorType);
  }
}
