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
    public async Task AddAsync(CalculatorHistory history)
    {
      await context.AddAsync(history);
      await context.SaveChangesAsync();
    }

    public async Task<List<CalculatorHistory>> GetHistoryAsync()
    {
      var result = await context.CalculatorHistories
          .OrderByDescending(calculatorHistory => calculatorHistory.Timestamp)
          .ToListAsync();

      return result;
    }
  }
}
