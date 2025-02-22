namespace PaySpace.Calculator.Application.Handlers.History.GetHistory
{
  public sealed class GetHistoryResponse
  {
    public string PostalCode { get; set; }

    public DateTime Timestamp { get; set; }

    public decimal Income { get; set; }

    public decimal Tax { get; set; }

    public string Calculator { get; set; }
  }
}