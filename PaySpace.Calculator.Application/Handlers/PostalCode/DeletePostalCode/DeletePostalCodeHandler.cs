namespace PaySpace.Calculator.Application.Handlers.PostalCode.DeletePostalCode
{
  using System.Threading.Tasks;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class DeletePostalCodeHandler(IPostalCodeService postalCodeService) : IHandler<DeletePostalCodeRequest, DeletePostalCodeResponse>
  {
    public async Task<DeletePostalCodeResponse> HandleAsync(DeletePostalCodeRequest query)
    {
      var hasDeleted = await postalCodeService.DeletePostalCodeAsync(query.Id);

      return new DeletePostalCodeResponse { HasDeleted = hasDeleted };
    }
  }
}
