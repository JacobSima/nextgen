namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  public interface ICalculatorSettingsRepository
  {
    Task<List<CalculatorSetting>> GetCalculatorSettings();
    Task<List<CalculatorSetting>> GetCalculatorSettingsByType(CalculatorType calculatorType);
  }
}
