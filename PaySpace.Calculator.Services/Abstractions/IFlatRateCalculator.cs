namespace PaySpace.Calculator.Services.Abstractions
{
  public interface IFlatRateCalculator : ITaxCalculator
  {
    new decimal CalculateTax(decimal annualIncome, int calculatorType);
    decimal CalculateTaxDetailsFlatRate(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome);
  }
}