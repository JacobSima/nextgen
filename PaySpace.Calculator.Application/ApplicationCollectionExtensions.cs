namespace PaySpace.Calculator.Application
{
  using Mapster;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services;
  using PaySpace.Calculator.Services.Configuration;

  public static class ApplicationCollectionExtensions
  {
    public static IServiceCollection ApplicationsServices(this IServiceCollection services, IConfiguration configuration)
    {
      MappingConfig.Configure();

      services.AddApiLayer();

      // Register Handlers
      services.AddHandlers();

      // Add services layer
      services.AddServicesLayer(configuration);

      return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
      var applicationAssembly = typeof(IAppHandler<>).Assembly;

      services.Scan(s => s.FromAssemblies(applicationAssembly)
        .AddClasses(c => c.AssignableTo(typeof(IHandler<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

      return services;
    }

    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      services.AddControllers();
      services.AddMapster();

      return services;
    }

    public static IServiceCollection AddServicesLayer(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddServices(configuration);

      return services;
    }

    // Use Application
    public static WebApplication UseApplication(this WebApplication app)
    {
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();
      app.UseRouting();
      app.MapControllers();

      //app.UseAuthorization();
      return app;
    }
  }
}
