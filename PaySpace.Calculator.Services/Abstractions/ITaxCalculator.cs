namespace PaySpace.Calculator.Services.Abstractions
{
  public interface ITaxCalculator
  {
    decimal CalculateTax(decimal annualIncome, int calculatorType);
  }
}
