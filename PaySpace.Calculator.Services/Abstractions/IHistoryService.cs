using PaySpace.Calculator.Data.Entities.CalculatorHistory;

namespace PaySpace.Calculator.Services.Abstractions
{
  public interface IHistoryService
    {
        Task<List<CalculatorHistory>> GetHistoryAsync();

        Task AddAsync(CalculatorHistory calculatorHistory);
    }
}