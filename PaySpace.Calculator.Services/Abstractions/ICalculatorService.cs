namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Services.Abstractions;

  public interface ICalculatorService
  {
    ITaxCalculator GetCalculator(int calculatorType);
    Task<IEnumerable<(decimal, decimal, decimal)>> GetCalculatorSettingByCalculatorType(int calculatorType);
    IEnumerable<(decimal, decimal, decimal)> MapCalculationSettings(List<CalculatorSetting> calculatorSettings);
    decimal CalculateTaxDetailsProgressive(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome);
    decimal CalculateTaxDetailsFlatValue(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome);
    decimal CalculateTaxDetailsFlatRate(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome);
  }
}
