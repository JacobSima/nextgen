namespace PaySpace.Calculator.Services.Calculators
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;
  using PaySpace.Calculator.Services.Abstractions;

  public class TaxCalculatorFactory(ICalculatorSettingsService calculatorSettingsService) : ITaxCalculatorFactory
  {
    public async Task<ITaxCalculator?> CreateCalculator(int calculatorType)
    {
      var settings = await GetCalculatorSettingByCalculatorType(calculatorType);

      return calculatorType switch
      {
        0 => new ProgressiveCalculator(settings),
        1 => new FlatValueCalculator(settings),
        2 => new FlatRateCalculator(settings),
        _ => null
      };
    }

    public async Task<IEnumerable<(decimal, decimal, decimal)>> GetCalculatorSettingByCalculatorType(int calculatorType)
    {
      var type = (CalculatorType)calculatorType;

      var calculationsSettings = await calculatorSettingsService.GetSettingsByCalculatorTypeAsync(type);

      var mappedSettings = MapCalculationSettings(calculationsSettings);

      return mappedSettings;
    }

    public IEnumerable<(decimal, decimal, decimal)> MapCalculationSettings(List<CalculatorSetting> calculatorSettings)
    {
      var calSettings = calculatorSettings?.Select(setting =>
      {
        var from = setting?.From ?? 0;
        var to = setting?.To ?? decimal.MaxValue;
        var rate = setting?.Rate ?? 0;
        return (from, to, rate);
      });

      return calSettings;
    }
  }
}
