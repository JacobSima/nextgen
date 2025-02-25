namespace PaySpace.Calculator.Web.Services.Abstractions
{
  using PaySpace.Calculator.Web.Services.Models;

  public interface ICalculatorHttpService
  {
    Task<List<PostalCode>> GetPostalCodesAsync();

    Task<List<CalculatorHistory>> GetHistoryAsync();
    Task DeleteHistoryAsync(int historyId);

    Task<CalculateResult> CalculateTaxAsync(CalculateRequest calculationRequest);
  }
}