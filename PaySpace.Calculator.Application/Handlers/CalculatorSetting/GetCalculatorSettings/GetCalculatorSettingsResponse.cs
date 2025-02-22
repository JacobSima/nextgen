﻿namespace PaySpace.Calculator.Application.Handlers.CalculatorSetting.GetCalculatorSettings
{
  public class GetCalculatorSettingsResponse
  {
    public long Id { get; set; }
    public long Calculator { get; set; }

    public long RateType { get; set; }

    public decimal Rate { get; set; }

    public decimal From { get; set; }

    public decimal? To { get; set; }
  }
}
