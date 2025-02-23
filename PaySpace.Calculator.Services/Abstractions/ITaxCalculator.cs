namespace PaySpace.Calculator.Services.Abstractions
{
  public interface ITaxCalculator
  {
    Task<decimal> CalculateTax(decimal annualIncome, int calculatorType);
  }
}
