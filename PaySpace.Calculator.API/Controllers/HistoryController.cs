namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.History.GetHistories;
  using PaySpace.Calculator.Application.Handlers.PostalCode.DeletePostalCode;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class HistoryController(
    IHandler<GetHistoriesRequest, IEnumerable<GetHistoriesResponse>> getHistoriesHandler,
    IHandler<DeleteHistoryRequest, DeleteHistoryResponse> deleteHistoryHandler,
    ILogger<HistoryController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetHistoriesResponse>>> Histories()
    {
      var histories = await getHistoriesHandler.HandleAsync(new GetHistoriesRequest());

      return this.Ok(histories);
    }

    [HttpDelete("{HistoryId}:int")]
    public async Task<ActionResult<DeleteHistoryResponse>> DeleteHistory(int HistoryId)
    {
      var response = await deleteHistoryHandler.HandleAsync(new DeleteHistoryRequest { Id = HistoryId });

      return this.Ok(response);
    }
  }
}