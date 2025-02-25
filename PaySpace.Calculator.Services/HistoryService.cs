namespace PaySpace.Calculator.Services
{
  using System.Collections.Generic;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  internal sealed class HistoryService(
    IHistoryRepository historyRepository,
    IInMemoryCache memoryCache
    ) : IHistoryService
  {
    public async Task AddAsync(CalculatorHistory history)
    {
      var isAddedToCache = await memoryCache.AddAndCacheAsync<CalculatorHistory>(
        "CalculatorHistories",
        () => historyRepository.AddAsync(history),
        history
      );
    }

    public async Task<List<CalculatorHistory>> GetHistoryAsync()
    {
      var histories = await memoryCache.GetOrCreateAsync<List<CalculatorHistory>>("CalculatorHistories", () => historyRepository.GetHistoriesAsync()) ?? [];

      return histories;
    }

    public async Task<bool> DeleteHistoryAsync(long historyId)
    {
      var existingHistory = await historyRepository.GetByIdAsync(historyId); ;

      if (existingHistory == null)
      {
        return false;
      }

      var isDeleted = await historyRepository.DeleteAsync(existingHistory);

      if (isDeleted)
      {
        memoryCache.RemoveValue<CalculatorHistory>("CalculatorHistories", history => history.Id == existingHistory.Id);
      }

      return isDeleted;
    }
  }
}