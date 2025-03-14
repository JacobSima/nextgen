﻿namespace PaySpace.Calculator.Application.Handlers.PostalCode.GetPostalCodes
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Abstractions;

  public class GetPostalCodesHandler(IPostalCodeService postalCodeService, IMapper mapper) : IHandler<GetPostalCodesRequest, IEnumerable<GetPostalCodesResponse>>
  {
    public async Task<IEnumerable<GetPostalCodesResponse>> HandleAsync(GetPostalCodesRequest query)
    {
      var postalCodes = await postalCodeService.GetPostalCodesAsync();

      var response = mapper.Map<IEnumerable<GetPostalCodesResponse>>(postalCodes);
      return response;
    }
  }
}
