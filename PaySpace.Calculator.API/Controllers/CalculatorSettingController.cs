namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetCalculatorSettings;
  using PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetSettingsByCalculatorType;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodes;
  using PaySpace.Calculator.Data.Model;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class CalculatorSettingController(
    IHandler<GetCalculatorSettingsRequest, IEnumerable<GetCalculatorSettingsResponse>> getCalculatorSettingsHandler,
    IHandler<GetSettingsByCalculatorTypeRequest, IEnumerable<GetSettingsByCalculatorTypeResponse>> getSettingsByCalculatorTypeHandler,
    ILogger<CalculatorSettingController> logger
    ) : ControllerBase
  {
    [HttpGet()]
    public async Task<ActionResult<List<GetPostalCodesResponse>>> CalculatorSettings()
    {
      var calculatorSettings = await getCalculatorSettingsHandler.HandleAsync(new GetCalculatorSettingsRequest());

      return this.Ok(calculatorSettings);
    }

    [HttpGet("{CalculatorType}:int")]
    public async Task<ActionResult<List<GetSettingsByCalculatorTypeResponse>>> GetSettingsByCalculatorTypeHandler(int CalculatorType)
    {
      var request = new GetSettingsByCalculatorTypeRequest { CalculatorType = (CalculatorType)CalculatorType };

      var calculatorSettings = await getSettingsByCalculatorTypeHandler.HandleAsync(request);

      return this.Ok(calculatorSettings);
    }
  }
}