namespace PaySpace.Calculator.Application.Handlers.PostalCode.GetCalculatorTypesByCode
{
  using PaySpace.Calculator.Application.Abstractions;

  public class GetCalculatorTypesByCodeRequest : IAppHandler<GetCalculatorTypesByCodeResponse>
  {
    public string Code { get; set; } = string.Empty;
  }
}
