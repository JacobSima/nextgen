﻿namespace PaySpace.Calculator.Data.Entities.CalculatorSetting
{
  public sealed class CalculatorSettingServiceRequest
  {
    public long? Id { get; set; }

    public long? Calculator { get; set; }

    public long? RateType { get; set; }

    public decimal Rate { get; set; }

    public decimal From { get; set; }

    public decimal? To { get; set; }
  }
}