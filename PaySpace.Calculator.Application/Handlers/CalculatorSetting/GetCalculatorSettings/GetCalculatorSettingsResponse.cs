namespace PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetCalculatorSettings
{
  using PaySpace.Calculator.Data.Models;

  public class GetCalculatorSettingsResponse
  {
    public CalculatorType Calculator { get; set; }

    public RateType RateType { get; set; }

    public decimal Rate { get; set; }

    public decimal From { get; set; }

    public decimal? To { get; set; }
  }
}
