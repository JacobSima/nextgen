namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetCalculatorSettings;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCode;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class CalculatorSettingController(
    IHandler<GetCalculatorSettingsRequest, IEnumerable<GetCalculatorSettingsResponse>> calculatorSettingsHandler,
    ILogger<CalculatorSettingController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetPostalCodesResponse>>> CalculatorSettings([FromQuery] GetCalculatorSettingsRequest getCalculatorSettingsRequest)
    {
      var calculatorSettings = await calculatorSettingsHandler.HandleAsync(getCalculatorSettingsRequest);

      return this.Ok(calculatorSettings);
    }
  }
}