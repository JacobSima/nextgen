namespace PaySpace.Calculator.Application.Handlers.PostalCode.GetCalculatorTypesByCode
{
  using System.Threading.Tasks;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class GetCalculatorTypesByCodeHandler(IPostalCodeService postalCodeService) : IHandler<GetCalculatorTypesByCodeRequest, GetCalculatorTypesByCodeResponse>
  {
    public async Task<GetCalculatorTypesByCodeResponse> HandleAsync(GetCalculatorTypesByCodeRequest query)
    {
      var calculatorTypes = await postalCodeService.GetCalculatorTypesByCodeAsync(query.Code);

      var response = new GetCalculatorTypesByCodeResponse
      {
        CalculatorType = calculatorTypes,
      };

      return response;
    }
  }
}
