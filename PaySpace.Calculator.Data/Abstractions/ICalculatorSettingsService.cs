namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  public interface ICalculatorSettingsService
  {
    Task<List<CalculatorSetting>> GetSettingspeAsync();
    Task<List<CalculatorSetting>> GetSettingsByCalculatorTypeAsync(CalculatorType calculatorType);
  }
}