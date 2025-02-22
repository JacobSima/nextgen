namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  using PaySpace.Calculator.API.Models;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.History.GetHistory;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class CalculatorController : ControllerBase
  {
    private readonly IHandler<GetHistoryRequest, IEnumerable<GetHistoryResponse>> getHistory;
    private readonly ILogger<CalculatorController> logger;

    public CalculatorController(
      ILogger<CalculatorController> logger,
      IHandler<GetHistoryRequest, IEnumerable<GetHistoryResponse>>? getHistory)
    {
      this.logger = logger;
      this.getHistory = getHistory;
    }

    //[HttpPost("calculate-tax")]
    //public async Task<ActionResult<CalculateResult>> Calculate(CalculateRequest request)
    //{
    //  try
    //  {

    //    var result = 0;

    //    await historyService.AddAsync(new CalculatorHistory
    //    {
    //      Tax = 0,
    //      Calculator = new CalculatorType(),
    //      PostalCode = request.PostalCode ?? "Unknown",
    //      Income = request.Income
    //    });

    //    return this.Ok(mapper.Map<CalculateResultDto>(result));
    //  }
    //  catch (CalculatorException e)
    //  {
    //    logger.LogError(e, e.Message);

    //    return this.BadRequest(e.Message);
    //  }
    //}

    [HttpGet("history")]
    public async Task<ActionResult<List<CalculatorHistoryDto>>> History([FromBody] GetHistoryRequest getHistory)
    {
      var histories = await this.getHistory.HandleAsync(getHistory);

      return this.Ok(histories);
    }
  }
}