namespace PaySpace.Calculator.Services.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;

  public interface ITaxCalculatorFactory
  {
    Task<ITaxCalculator?> CreateCalculator(int calculatorType);
    Task<IEnumerable<(decimal, decimal, decimal)>> GetCalculatorSettingByCalculatorType(int calculatorType);
    IEnumerable<(decimal, decimal, decimal)> MapCalculationSettings(List<CalculatorSetting> calculatorSettings);
  }
}
