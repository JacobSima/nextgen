namespace PaySpace.Calculator.Services
{
  using System.Collections.Generic;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  internal sealed class HistoryService(IHistoryRepository historyRepository) : IHistoryService
  {
    public async Task AddAsync(CalculatorHistory history)
    {
      history.Timestamp = DateTime.Now;
      await historyRepository.AddAsync(history);
    }

    public async Task<List<CalculatorHistory>> GetHistoryAsync()
    {
      var result = await historyRepository.GetHistoryAsync();

      return result;
    }
  }
}