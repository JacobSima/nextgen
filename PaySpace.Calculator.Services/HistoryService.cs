namespace PaySpace.Calculator.Services
{
  using System.Collections.Generic;
  using Microsoft.EntityFrameworkCore;

  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class HistoryService(CalculatorContext context) : IHistoryService
  {
    public async Task AddAsync(CalculatorHistory history)
    {
      history.Timestamp = DateTime.Now;

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