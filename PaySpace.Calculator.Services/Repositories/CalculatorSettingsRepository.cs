namespace PaySpace.Calculator.Services.Repositories
{
  using Microsoft.EntityFrameworkCore;
  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;

  internal sealed class CalculatorSettingsRepository(CalculatorContext context) : ICalculatorSettingsRepository
  {
    public async Task<List<CalculatorSetting>> GetCalculatorSettings()
    {
      var calculatorSettings = await context.CalculatorSettings
        .AsNoTracking()
        .ToListAsync();

      return calculatorSettings;
    }

    public async Task<List<CalculatorSetting>> GetCalculatorSettingsByType(CalculatorType calculatorType)
    {
      var types = await context.CalculatorSettings
        .AsNoTracking()
        .Where(calculatorSetting => calculatorSetting.Calculator == calculatorType)
        .ToListAsync();

      return types;
    }
  }
}
