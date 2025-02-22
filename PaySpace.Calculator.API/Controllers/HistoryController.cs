namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.History.GetHistory;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class HistoryController(
    IHandler<GetHistoriesRequest, IEnumerable<GetHistoriesResponse>> getHistoryHandler,
    ILogger<HistoryController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetHistoriesResponse>>> Histories([FromQuery] GetHistoriesRequest getHistoryRequest)
    {
      var histories = await getHistoryHandler.HandleAsync(getHistoryRequest);

      return this.Ok(histories);
    }
  }
}