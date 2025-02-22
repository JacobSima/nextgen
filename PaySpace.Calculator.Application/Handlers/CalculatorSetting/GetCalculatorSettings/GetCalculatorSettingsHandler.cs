namespace PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetCalculatorSettings
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class GetCalculatorSettingsHandler(ICalculatorSettingsService calculatorSettingsService, IMapper mapper)
    : IHandler<GetCalculatorSettingsRequest, IEnumerable<GetCalculatorSettingsResponse>>
  {
    public async Task<IEnumerable<GetCalculatorSettingsResponse>> HandleAsync(GetCalculatorSettingsRequest query)
    {
      var calculatorSettings = await calculatorSettingsService.GetSettingspeAsync();

      var response = mapper.Map<IEnumerable<GetCalculatorSettingsResponse>>(calculatorSettings);
      return response;
    }
  }
}
