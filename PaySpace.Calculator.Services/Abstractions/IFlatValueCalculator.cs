namespace PaySpace.Calculator.Services.Abstractions
{
  public interface IFlatValueCalculator : ITaxCalculator
  {
    new decimal CalculateTax(decimal annualIncome);
    decimal CalculateTaxDetailsFlatValue(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome);
  }
}