namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  public interface IHistoryRepository
  {
    Task<bool> AddAsync(CalculatorHistory history);
    Task<List<CalculatorHistory>> GetHistoriesAsync();
  }
}
