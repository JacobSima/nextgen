namespace PaySpace.Calculator.Application.Handlers.PostalCode.DeletePostalCode
{
  using System.Threading.Tasks;
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Abstractions;

  public class DeleteHistoryHandler(IHistoryService historyService) : IHandler<DeleteHistoryRequest, DeleteHistoryResponse>
  {
    public async Task<DeleteHistoryResponse> HandleAsync(DeleteHistoryRequest query)
    {
      var hasDeleted = await historyService.DeleteHistoryAsync(query.Id);

      return new DeleteHistoryResponse { HasDeleted = hasDeleted };
    }
  }
}
