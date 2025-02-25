namespace PaySpace.Calculator.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Application.Handlers.PostalCode.AddPostalCode;
  using PaySpace.Calculator.Application.Handlers.PostalCode.DeletePostalCode;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetCalculatorTypesByCode;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodeById;
  using PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodes;
  using PaySpace.Calculator.Application.Handlers.PostalCode.UpdatePostalCode;

  [ApiController]
  [Route("api/[Controller]")]
  public sealed class PostalCodeController(
    IHandler<GetPostalCodesRequest, IEnumerable<GetPostalCodesResponse>> getPostalCodeHandler,
    IHandler<GetPostalCodeByIdRequest, GetPostalCodeByIdResponse> getPostalCodeByIdHandler,
    IHandler<AddPostalCodeRequest, AddPostalCodeResponse> addPostalCodeHandler,
    IHandler<UpdatePostalCodeRequest, UpdatePostalCodeResponse> updatePostalCodeHandler,
    IHandler<DeletePostalCodeRequest, DeletePostalCodeResponse> deletePostalCodeHandler,
    IHandler<GetCalculatorTypesByCodeRequest, GetCalculatorTypesByCodeResponse> getCalculatorTypesByCode,
    ILogger<PostalCodeController> logger
    ) : ControllerBase
  {

    [HttpGet()]
    public async Task<ActionResult<List<GetPostalCodesResponse>>> PostalCodes()
    {
      var postalCodes = await getPostalCodeHandler.HandleAsync(new GetPostalCodesRequest());

      return this.Ok(postalCodes);
    }

    [HttpGet("{PostalCodeId}:int")]
    public async Task<ActionResult<GetPostalCodeByIdResponse>> PostalCodeById(int PostalCodeId)
    {
      var postalCodes = await getPostalCodeByIdHandler.HandleAsync(new GetPostalCodeByIdRequest { PostalCodeId = PostalCodeId });

      return this.Ok(postalCodes);
    }

    [HttpPost()]
    public async Task<ActionResult<AddPostalCodeResponse>> AddPostalCode([FromBody] AddPostalCodeRequest addPostalCodeRequest)
    {
      var postalCodes = await addPostalCodeHandler.HandleAsync(addPostalCodeRequest);

      return this.Ok(postalCodes);
    }

    [HttpPut("{PostalCodeId}:int")]
    public async Task<ActionResult<UpdatePostalCodeResponse>> UpdatePostalCode(int PostalCodeId, [FromBody] UpdatePostalCodeRequest addPostalCodeRequest)
    {
      addPostalCodeRequest.Id = PostalCodeId;

      var response = await updatePostalCodeHandler.HandleAsync(addPostalCodeRequest);

      return this.Ok(response);
    }

    [HttpDelete("{PostalCodeId}:int")]
    public async Task<ActionResult<DeletePostalCodeResponse>> DeletePostalCode(int PostalCodeId)
    {
      var response = await deletePostalCodeHandler.HandleAsync(new DeletePostalCodeRequest { Id = PostalCodeId });

      return this.Ok(response);
    }

    [HttpGet("/GetCalculatorTypesByCode/{PostalCode}:string")]
    public async Task<ActionResult<GetCalculatorTypesByCodeResponse>> GetCalculatorTypesByCode(string PostalCode)
    {
      var calculatorType = await getCalculatorTypesByCode.HandleAsync(new GetCalculatorTypesByCodeRequest { Code = PostalCode });

      return this.Ok(calculatorType);
    }
  }
}