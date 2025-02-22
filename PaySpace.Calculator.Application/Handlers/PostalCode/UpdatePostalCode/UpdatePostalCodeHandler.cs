namespace PaySpace.Calculator.Application.Handlers.PostalCode.UpdatePostalCode
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Entities.PostalCode;
  using PaySpace.Calculator.Services.Abstractions;

  public class UpdatePostalCodeHandler(IPostalCodeService postalCodeService, IMapper mapper) : IHandler<UpdatePostalCodeRequest, UpdatePostalCodeResponse>
  {
    public async Task<UpdatePostalCodeResponse> HandleAsync(UpdatePostalCodeRequest query)
    {
      var request = mapper.Map<PostalCodeServiceRequest>(query);

      var hasUpdated = await postalCodeService.UpdatePostalCodeAsync(query.Id, request);

      return new UpdatePostalCodeResponse { HasUpdated = hasUpdated };
    }
  }
}
