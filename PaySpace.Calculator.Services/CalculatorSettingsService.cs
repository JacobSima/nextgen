namespace PaySpace.Calculator.Services
{
  using Microsoft.Extensions.Caching.Memory;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  internal sealed class CalculatorSettingsService(ICalculatorSettingsRepository calculatorSettingsRepository, IMemoryCache memoryCache) : ICalculatorSettingsService
  {
    public async Task<List<CalculatorSetting>> GetSettingspeAsync()
    {
      var calculatorSettings = await memoryCache.GetOrCreateAsync("CalculatorSetting", async entry =>
      {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);

        var settings = await calculatorSettingsRepository.GetCalculatorSettings();

        return settings;
      }) ?? [];

      return calculatorSettings;
    }

    public async Task<List<CalculatorSetting>> GetSettingsByCalculatorTypeAsync(CalculatorType calculatorType)
    {
      var calculatorSettings = await memoryCache.GetOrCreateAsync($"CalculatorSetting:{calculatorType}", async entry =>
      {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);

        var types = await calculatorSettingsRepository.GetCalculatorSettingsByType(calculatorType);

        return types;
      }) ?? [];

      return calculatorSettings;
    }
  }
}