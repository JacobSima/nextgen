namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetCalculatorSettings;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodes;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class CalculatorSettingController(
    IHandler<GetCalculatorSettingsRequest, IEnumerable<GetCalculatorSettingsResponse>> getCalculatorSettingsHandler,
    ILogger<CalculatorSettingController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetPostalCodesResponse>>> CalculatorSettings()
    {
      var calculatorSettings = await getCalculatorSettingsHandler.HandleAsync(new GetCalculatorSettingsRequest());

      return this.Ok(calculatorSettings);
    }
  }
}