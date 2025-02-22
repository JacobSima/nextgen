namespace PaySpace.Calculator.Application.Handlers.StaticData
{
  using System.Threading.Tasks;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Helpers;
  using PaySpace.Calculator.Data.Model;

  public class GetStaticDataHandler : IHandler<GetStaticDataRequest, GetStaticDataResponse>
  {
    public async Task<GetStaticDataResponse> HandleAsync(GetStaticDataRequest query)
    {
      var calculatorTypes = GetEnumValueHelper.GetEnumOptions<CalculatorType>();

      var rateTypes = GetEnumValueHelper.GetEnumOptions<RateType>();

      var response = new GetStaticDataResponse
      {
        Calculatortypes = calculatorTypes,
        RateTypes = rateTypes
      };

      await Task.CompletedTask;
      return response;
    }


  }
}
