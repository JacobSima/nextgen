namespace PaySpace.Calculator.Application.Handlers.PostalCode.DeletePostalCode
{
  using PaySpace.Calculator.Application.Abstractions;

  public class DeletePostalCodeRequest : IAppHandler<DeletePostalCodeResponse>
  {
    public long Id { get; set; }
  }
}
