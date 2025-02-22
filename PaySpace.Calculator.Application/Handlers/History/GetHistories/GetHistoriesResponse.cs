namespace PaySpace.Calculator.Application.Handlers.History.GetHistories
{
  public sealed class GetHistoriesResponse
  {
    public long Id { get; set; }
    public string PostalCode { get; set; }

    public DateTime Timestamp { get; set; }

    public decimal Income { get; set; }

    public decimal Tax { get; set; }

    public long Calculator { get; set; }
  }
}