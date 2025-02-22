namespace PaySpace.Calculator.Web.Models
{
  using PaySpace.Calculator.Web.Services.Models;

  public sealed class CalculatorViewModel
  {
    public List<PostalCode>? PostalCodes { get; set; }

    public string PostalCode { get; set; }

    public decimal Income { get; set; }
  }
}