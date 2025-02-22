namespace PaySpace.Calculator.Application.Handlers.History.GetHistory
{
  using System.Threading.Tasks;
  using MapsterMapper;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Services.Abstractions;

  public class GetHistoryHandler(IHistoryService historyService, IMapper mapper) : IHandler<GetHistoryRequest, IEnumerable<GetHistoryResponse>>
  {
    private readonly IHistoryService historyService = historyService;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<GetHistoryResponse>> HandleAsync(GetHistoryRequest query)
    {
      var history = await historyService.GetHistoryAsync();

      var response = mapper.Map<IEnumerable<GetHistoryResponse>>(history);
      return response;
    }
  }
}
