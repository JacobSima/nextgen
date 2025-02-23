namespace PaySpace.Calculator.Application.Handlers.StaticData
{
  using System.Threading.Tasks;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  public class CalculatorHandler(
    ICalculatorService calculatorService,
    IPostalCodeService postalCodeService,
    IHistoryService historyService
    ) : IHandler<CalculatorRequest, CalculatorResponse>
  {
    public async Task<CalculatorResponse> HandleAsync(CalculatorRequest query)
    {
      var calculatorType = await postalCodeService.GetCalculatorTypesByCodeAsync(query.PostalCode);
      var type = (int)calculatorType;

      // Get calculator from TaxCalculator Factory
      var calculator = calculatorService.GetCalculator(type);

      if (calculator == null)
      {
        return new CalculatorResponse();
      }

      // Calculate the tax details
      var taxValue = await calculator.CalculateTax(query.Income, type);

      var history = new CalculatorHistory
      {
        PostalCode = query.PostalCode,
        Timestamp = DateTime.Now,
        Income = query.Income,
        Tax = taxValue,
        Calculator = calculatorType
      };

      // Add history
      await historyService.AddAsync(history);

      return new CalculatorResponse { Tax = taxValue, Calculator = calculatorType.ToString() };
    }
  }
}
