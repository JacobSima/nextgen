namespace PaySpace.Calculator.Application.Handlers.History.GetHistory
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class GetHistoriesHandler(IHistoryService historyService, IMapper mapper) : IHandler<GetHistoriesRequest, IEnumerable<GetHistoriesResponse>>
  {
    public async Task<IEnumerable<GetHistoriesResponse>> HandleAsync(GetHistoriesRequest query)
    {
      var histories = await historyService.GetHistoryAsync();

      var response = mapper.Map<IEnumerable<GetHistoriesResponse>>(histories);
      return response;
    }
  }
}
