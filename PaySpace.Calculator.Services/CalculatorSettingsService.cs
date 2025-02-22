namespace PaySpace.Calculator.Services
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Caching.Memory;

  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Models;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class CalculatorSettingsService(CalculatorContext context, IMemoryCache memoryCache) : ICalculatorSettingsService
  {
    public async Task<List<CalculatorSetting>> GetSettingspeAsync()
    {
      var calculatorSettings = await memoryCache.GetOrCreateAsync("CalculatorSetting", entry =>
      {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);

        return context.CalculatorSettings
        .AsNoTracking()
        .ToListAsync();
      }) ?? [];

      return calculatorSettings;
    }

    public async Task<List<CalculatorSetting>> GetSettingsByCalculatorTypeAsync(CalculatorType calculatorType)
    {
      var calculatorSettings = await memoryCache.GetOrCreateAsync($"CalculatorSetting:{calculatorType}", entry =>
      {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);

        return context.CalculatorSettings
        .AsNoTracking()
        .Where(calculatorSetting => calculatorSetting.Calculator == calculatorType)
        .ToListAsync();
      }) ?? [];

      return calculatorSettings;
    }
  }
}