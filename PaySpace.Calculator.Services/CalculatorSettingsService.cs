namespace PaySpace.Calculator.Services
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  internal sealed class CalculatorSettingsService(ICalculatorSettingsRepository calculatorSettingsRepository, IInMemoryCache memoryCache) : ICalculatorSettingsService
  {
    public async Task<List<CalculatorSetting>> GetAllSettingsAsync()
    {
      var calculatorSettings = await memoryCache.GetOrCreateAsync<List<CalculatorSetting>>("CalculatorSetting", () => calculatorSettingsRepository.GetCalculatorSettings()) ?? [];

      return calculatorSettings;
    }

    public async Task<List<CalculatorSetting>> GetSettingsByCalculatorTypeAsync(CalculatorType calculatorType)
    {
      var calculatorSettings = await memoryCache.GetOrCreateByIdAsync<List<CalculatorSetting>>(
        "CalculatorSetting",
        calculatorSetting => calculatorSetting.Any(cal => cal.Calculator == calculatorType),
        () => calculatorSettingsRepository.GetCalculatorSettingsByType(calculatorType)
       );

      return calculatorSettings;
    }
  }
}