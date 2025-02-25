namespace PaySpace.Calculator.Services.Models
{
  using PaySpace.Calculator.Data.Model;

  public sealed class CalculateResult
  {
    public CalculatorType Calculator { get; set; }

    public decimal Tax { get; set; }
  }
}