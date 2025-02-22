namespace PaySpace.Calculator.Application.Handlers.PostalCode.UpdatePostalCode
{
  using PaySpace.Calculator.Application.Abstractions;

  public class UpdatePostalCodeRequest : IAppHandler<UpdatePostalCodeResponse>
  {
    public long? Id { get; set; }
    public string Code { get; set; }

    public string Calculator { get; set; }
  }
}
