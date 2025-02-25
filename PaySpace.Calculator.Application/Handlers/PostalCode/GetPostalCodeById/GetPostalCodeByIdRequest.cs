namespace PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodeById
{
  using PaySpace.Calculator.Application.Abstractions;

  public class GetPostalCodeByIdRequest : IAppHandler<GetPostalCodeByIdResponse>
  {
    public int PostalCodeId { get; set; }
  }
}
