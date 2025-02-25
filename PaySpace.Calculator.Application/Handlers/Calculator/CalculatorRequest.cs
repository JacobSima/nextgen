namespace PaySpace.Calculator.Application.Handlers.StaticData
{
  using PaySpace.Calculator.Application.Abstractions;

  public class CalculatorRequest : IAppHandler<CalculatorResponse>
  {
    public decimal Income { get; set; }
    public string PostalCode { get; set; }
  }
}
