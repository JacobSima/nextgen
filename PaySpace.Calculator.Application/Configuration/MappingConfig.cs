namespace PaySpace.Calculator.Services.Configuration
{
  using Mapster;
  using PaySpace.Calculator.Application.Handlers.History.GetHistories;
  using PaySpace.Calculator.Data.Entities.CalculatorHistory;

  public class MappingConfig
  {
    public static void Configure()
    {
      TypeAdapterConfig<CalculatorHistory, GetHistoriesResponse>
        .NewConfig()
        .Map(dest => dest.Calculator, src => src.Calculator.ToString());
    }
  }

}
