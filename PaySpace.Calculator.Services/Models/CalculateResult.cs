namespace PaySpace.Calculator.Services.Models
{
  using PaySpace.Calculator.Data.Models;

  public sealed class CalculateResult
  {
    public CalculatorType Calculator { get; set; }

    public decimal Tax { get; set; }
  }
}