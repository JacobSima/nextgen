namespace PaySpace.Calculator.Application.Handlers.StaticData
{
  using System.Collections.Generic;
  using PaySpace.Calculator.Application.Helpers;

  public class GetStaticDataResponse
  {
    public List<EnumOption> Calculatortypes { get; set; }
    public List<EnumOption> RateTypes { get; set; }
  }
}
