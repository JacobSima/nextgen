namespace PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetSettingsByCalculatorType
{
  using PaySpace.Calculator.Application.Abstractions;
  using PaySpace.Calculator.Data.Model;

  public class GetSettingsByCalculatorTypeRequest : IAppHandler<IEnumerable<GetSettingsByCalculatorTypeResponse>>
  {
    public CalculatorType CalculatorType { get; set; }
  }
}
