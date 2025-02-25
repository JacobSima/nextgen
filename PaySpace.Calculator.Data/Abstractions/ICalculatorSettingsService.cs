namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  public interface ICalculatorSettingsService
  {
    Task<List<CalculatorSetting>> GetAllSettingsAsync();
    Task<List<CalculatorSetting>> GetSettingsByCalculatorTypeAsync(CalculatorType calculatorType);
  }
}