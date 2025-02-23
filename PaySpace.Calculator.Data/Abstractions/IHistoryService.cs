namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  public interface IHistoryService
  {
    Task<List<CalculatorHistory>> GetHistoryAsync();

    Task AddAsync(CalculatorHistory calculatorHistory);
  }
}