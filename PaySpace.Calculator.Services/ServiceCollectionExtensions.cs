namespace PaySpace.Calculator.Services
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Services.Abstractions;
  using PaySpace.Calculator.Services.Calculators;

  public static class ServiceCollectionExtensions
  {
    // NB: This project could be named infrastructure for better readability
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<IPostalCodeService, PostalCodeService>();
      services.AddScoped<IHistoryService, HistoryService>();
      services.AddScoped<ICalculatorSettingsService, CalculatorSettingsService>();

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