namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.StaticData;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class CalculatorController(
    IHandler<CalculatorRequest, CalculatorResponse> calculatorHandler,
    ILogger<CalculatorController> logger
    ) : ControllerBase
  {

    [HttpPost()]
    public async Task<ActionResult<CalculatorResponse>> Calculator([FromBody] CalculatorRequest calculatorRequest)
    {
      var calculator = await calculatorHandler.HandleAsync(calculatorRequest);

      return this.Ok(calculator);
    }
  }
}