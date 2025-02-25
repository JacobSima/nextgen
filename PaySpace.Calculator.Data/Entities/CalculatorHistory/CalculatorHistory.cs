namespace PaySpace.Calculator.Data.Entities.CalculatorHistory
{
  using System.ComponentModel.DataAnnotations;
  using PaySpace.Calculator.Data.Model;

  public sealed class CalculatorHistory
  {
    [Key]
    public long Id { get; set; }

    public string PostalCode { get; set; }

    public DateTime Timestamp { get; set; }

    public decimal Income { get; set; }

    public decimal Tax { get; set; }

    public CalculatorType Calculator { get; set; }
  }
}