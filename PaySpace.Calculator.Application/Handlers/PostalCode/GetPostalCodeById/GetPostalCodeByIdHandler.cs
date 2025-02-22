namespace PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodeById
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class GetPostalCodeByIdHandler(IPostalCodeService postalCodeService, IMapper mapper) : IHandler<GetPostalCodeByIdRequest, GetPostalCodeByIdResponse>
  {
    public async Task<GetPostalCodeByIdResponse> HandleAsync(GetPostalCodeByIdRequest query)
    {
      var postalCodes = await postalCodeService.GetPostalCodeByIdAsync(query.PostalCodeId);

      var response = mapper.Map<GetPostalCodeByIdResponse>(postalCodes);
      return response;
    }
  }
}
