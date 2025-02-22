namespace PaySpace.Calculator.Application.Handlers.PostalCode.AddPostalCode
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Entities.PostalCode;
  using PaySpace.Calculator.Services.Abstractions;

  public class AddPostalCodeHandler(IPostalCodeService postalCodeService, IMapper mapper) : IHandler<AddPostalCodeRequest, AddPostalCodeResponse>
  {
    public async Task<AddPostalCodeResponse> HandleAsync(AddPostalCodeRequest query)
    {
      var request = mapper.Map<PostalCodeServiceRequest>(query);

      var postalCode = await postalCodeService.AddPostalCodeAsync(request);

      var response = mapper.Map<AddPostalCodeResponse>(postalCode);

      return response;
    }
  }
}
