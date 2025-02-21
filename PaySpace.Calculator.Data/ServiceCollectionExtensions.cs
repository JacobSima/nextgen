namespace PaySpace.Calculator.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  public static class ServiceCollectionExtensions
  {
    public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
      services
        .AddDbContext<CalculatorContext>(opt => opt.UseSqlite(configuration.GetConnectionString("CalculatorDatabase")))
        .AddHostedService<DatabaseInitializer>();
    }
  }
}