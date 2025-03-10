﻿namespace PaySpace.Calculator.Application.Handlers.History.GetHistories
{
  using System.Threading.Tasks;
  using Mapster;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Abstractions;

  public class GetHistoriesHandler(IHistoryService historyService, IMapper mapper) : IHandler<GetHistoriesRequest, IEnumerable<GetHistoriesResponse>>
  {
    public async Task<IEnumerable<GetHistoriesResponse>> HandleAsync(GetHistoriesRequest query)
    {
      var histories = await historyService.GetHistoryAsync();

      var response = histories.Adapt<IEnumerable<GetHistoriesResponse>>();

      return response;
    }
  }
}
