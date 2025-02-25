namespace PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetSettingsByCalculatorType
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Abstractions;

  public class GetSettingsByCalculatorTypeHandler(ICalculatorSettingsService calculatorSettingsService, IMapper mapper)
    : IHandler<GetSettingsByCalculatorTypeRequest, IEnumerable<GetSettingsByCalculatorTypeResponse>>
  {
    public async Task<IEnumerable<GetSettingsByCalculatorTypeResponse>> HandleAsync(GetSettingsByCalculatorTypeRequest query)
    {
      var calculatorSettings = await calculatorSettingsService.GetSettingsByCalculatorTypeAsync(query.CalculatorType);

      var response = mapper.Map<IEnumerable<GetSettingsByCalculatorTypeResponse>>(calculatorSettings);

      return response;
    }
  }
}
