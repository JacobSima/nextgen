namespace PaySpace.Calculator.Data.Entities.PostalCode
{
  public class PostalCodeServiceRequest
  {
    public long? Id { get; set; }
    public string? Code { get; set; } = string.Empty;

    public string? Calculator { get; set; } = string.Empty;
  }
}
