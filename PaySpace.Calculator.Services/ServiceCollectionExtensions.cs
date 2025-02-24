namespace PaySpace.Calculator.Services
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;
  using PaySpace.Calculator.Services.Calculators;
  using PaySpace.Calculator.Services.Repositories;

  public static class ServiceCollectionExtensions
  {
    // NB: This project could be named infrastructure for better readability
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();
      services.AddScoped<IPostalCodeService, PostalCodeService>();
      services.AddScoped<IHistoryRepository, HistoryRepository>();
      services.AddScoped<IHistoryService, HistoryService>();
      services.AddScoped<ICalculatorSettingsRepository, CalculatorSettingsRepository>();
      services.AddScoped<ICalculatorSettingsService, CalculatorSettingsService>();
      services.AddScoped<ICalculatorService, CalculatorService>();
      services.AddScoped<ITaxCalculatorFactory, TaxCalculatorFactory>();

      services.AddScoped<IFlatRateCalculator, FlatRateCalculator>();
      services.AddScoped<IFlatValueCalculator, FlatValueCalculator>();
      services.AddScoped<IProgressiveCalculator, ProgressiveCalculator>();

      // Add In Memory Cache
      services.AddMemoryCache();

      // add Database service
      services.AddData(configuration);

      return services;
    }
  }
}