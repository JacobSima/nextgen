namespace PaySpace.Calculator.Services
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorSetting;
  using PaySpace.Calculator.Data.Model;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class CalculatorService(
    ICalculatorSettingsService calculatorSettingsService,
    ITaxCalculatorFactory taxCalculatorFactory
   ) : ICalculatorService
  {
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

    public decimal CalculateTaxDetailsProgressive(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome)
    {
      var taxValue = 0m;

      foreach (var (from, to, rate) in settings)
      {
        if (annualIncome > from)
        {
          var taxableAmount = Math.Min(annualIncome, to) - from;
          taxValue += (taxableAmount * rate) / 100;

          if (annualIncome <= to)
          {
            break;
          }
        }
      }

      return taxValue;
    }

    public decimal CalculateTaxDetailsFlatValue(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome)
    {
      var taxValue = 0m;

      foreach (var (from, to, rate) in settings)
      {
        if (annualIncome < from || annualIncome > to)
        {
          continue;
        }

        return rate == 10000 ? rate : (annualIncome * rate) / 100;
      }

      return taxValue;
    }

    public decimal CalculateTaxDetailsFlatRate(IEnumerable<(decimal, decimal, decimal)> settings, decimal annualIncome)
    {
      var taxValue = 0m;

      foreach (var (from, to, rate) in settings)
      {
        if (annualIncome < from || annualIncome > to)
        {
          continue;
        }

        return (annualIncome * rate) / 100;
      }

      return taxValue;
    }

    public ITaxCalculator GetCalculator(int calculatorType)
    {
      var calculator = taxCalculatorFactory.CreateCalculator(calculatorType, this);

      return calculator;
    }

  }
}
