namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.StaticData;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class StaticDataController(
    IHandler<GetStaticDataRequest, GetStaticDataResponse> getStaticData
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<GetStaticDataResponse>> GetStaticData()
    {
      var staticData = await getStaticData.HandleAsync(new GetStaticDataRequest());

      return this.Ok(staticData);
    }
  }
}