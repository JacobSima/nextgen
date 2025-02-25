namespace PaySpace.Calculator.Application.Handlers.PostalCode.AddPostalCode
{
  using PaySpace.Calculator.Application.Abstractions;

  public class AddPostalCodeRequest : IAppHandler<AddPostalCodeResponse>
  {
    public string Code { get; set; }

    public string Calculator { get; set; }
  }
}
