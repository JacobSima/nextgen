namespace PaySpace.Calculator.Services.Abstractions
{
  public interface IProgressiveCalculator : ITaxCalculator
  {
    new decimal CalculateTax(decimal annualIncome, int calculatorType);
    decimal CalculateTaxDetailsProgressive(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome);
  }
}