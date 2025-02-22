namespace PaySpace.Calculator.Services.Abstractions
{
  using PaySpace.Calculator.Data.Models;

  public interface ICalculatorSettingsService
  {
    Task<List<CalculatorSetting>> GetSettingspeAsync();
    Task<List<CalculatorSetting>> GetSettingsByCalculatorTypeAsync(CalculatorType calculatorType);
  }
}