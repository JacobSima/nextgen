namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCode;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class PostalCodeController(
    IHandler<GetPostalCodesRequest, IEnumerable<GetPostalCodesResponse>> getHistoryHandler,
    ILogger<PostalCodeController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetPostalCodesResponse>>> PostalCodes([FromQuery] GetPostalCodesRequest getPostalCodeRequest)
    {
      var postalCodes = await getHistoryHandler.HandleAsync(getPostalCodeRequest);

      return this.Ok(postalCodes);
    }
  }
}