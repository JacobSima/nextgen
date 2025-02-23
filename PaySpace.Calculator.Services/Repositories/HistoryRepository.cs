namespace PaySpace.Calculator.Services.Repositories
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  internal sealed class HistoryRepository(CalculatorContext context) : IHistoryRepository
  {
    public async Task<bool> AddAsync(CalculatorHistory history)
    {
      await context.AddAsync(history);
      var addedCount = await context.SaveChangesAsync();

      return addedCount > 0;
    }

    public async Task<List<CalculatorHistory>> GetHistoriesAsync()
    {
      var result = await context.CalculatorHistories
          .OrderByDescending(calculatorHistory => calculatorHistory.Timestamp)
          .ToListAsync();

      return result;
    }
  }
}
