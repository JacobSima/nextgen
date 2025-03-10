﻿namespace PaySpace.Calculator.Data.Entities.PostalCode
{
  using System.ComponentModel.DataAnnotations;
  using PaySpace.Calculator.Data.Model;

  public sealed class PostalCode
  {
    [Key]
    public long Id { get; set; }

    public string Code { get; set; }

    public CalculatorType Calculator { get; set; }
  }
}