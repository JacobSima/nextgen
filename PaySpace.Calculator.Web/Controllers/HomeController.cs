namespace PaySpace.Calculator.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  public class HomeController() : Controller
  {
    public IActionResult Index()
    {
      return this.View();
    }

    public IActionResult Privacy()
    {
      return this.View();
    }
  }
}