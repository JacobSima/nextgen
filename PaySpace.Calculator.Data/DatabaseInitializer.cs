namespace PaySpace.Calculator.Data
{
  using System;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;

  internal sealed class DatabaseInitializer : IHostedService
  {
    private readonly IServiceProvider _serviceProvider;
    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      using var scope = _serviceProvider.CreateAsyncScope();
      var context = scope.ServiceProvider.GetRequiredService<CalculatorContext>();

      var pendingMigrations = context.Database.GetPendingMigrations().ToList();
      var hasPendingMigrations = pendingMigrations.Any();

      if (hasPendingMigrations)
      {
        await context.Database.MigrateAsync(cancellationToken);
      }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    => Task.CompletedTask;
  }
}
