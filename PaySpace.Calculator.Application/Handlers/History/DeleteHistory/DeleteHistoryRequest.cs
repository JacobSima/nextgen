namespace PaySpace.Calculator.Application.Handlers.PostalCode.DeletePostalCode
{
  using PaySpace.Calculator.Application.Abstractions;

  public class DeleteHistoryRequest : IAppHandler<DeleteHistoryResponse>
  {
    public long Id { get; set; }
  }
}
