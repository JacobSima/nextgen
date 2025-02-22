namespace PaySpace.Calculator.Data.Entities.CalculatorHistory
{
  public sealed class CalculatorHistoryServiceRequest
  {
    public long? Id { get; set; }

    public string? PostalCode { get; set; }

    public DateTime? Timestamp { get; set; }

    public decimal? Income { get; set; }

    public decimal? Tax { get; set; }

    public long? Calculator { get; set; }
  }
}