namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.History.GetHistories;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class HistoryController(
    IHandler<GetHistoriesRequest, IEnumerable<GetHistoriesResponse>> getHistoriesHandler,
    ILogger<HistoryController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetHistoriesResponse>>> Histories()
    {
      var histories = await getHistoriesHandler.HandleAsync(new GetHistoriesRequest());

      return this.Ok(histories);
    }
  }
}