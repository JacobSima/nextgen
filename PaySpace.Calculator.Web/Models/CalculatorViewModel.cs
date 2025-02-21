namespace PaySpace.Calculator.Web.Models
{
  using Microsoft.AspNetCore.Mvc.Rendering;

  public sealed class CalculatorViewModel
  {
    public SelectList? PostalCodes { get; set; }

    public string PostalCode { get; set; }

    public decimal Income { get; set; }
  }
}