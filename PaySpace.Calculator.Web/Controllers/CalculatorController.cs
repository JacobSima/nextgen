namespace PaySpace.Calculator.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  using PaySpace.Calculator.Web.Models;
  using PaySpace.Calculator.Web.Services.Abstractions;
  using PaySpace.Calculator.Web.Services.Models;

  public class CalculatorController(ICalculatorHttpService calculatorHttpService) : Controller
  {
    public async Task<IActionResult> Index()
    {
      var calculatorViewModel = await this.GetCalculatorViewModelAsync();

      return this.View(calculatorViewModel);
    }

    public async Task<IActionResult> PostalCodeDetails()
    {
      var calculatorViewModel = await this.GetCalculatorViewModelAsync();

      return this.View(calculatorViewModel);
    }

    public async Task<IActionResult> History()
    {
      var histories = await calculatorHttpService.GetHistoryAsync();
      var viewHistoryData = new CalculatorHistoryViewModel { CalculatorHistory = histories };

      return this.View(viewHistoryData);
    }

    [HttpPost]
    [ValidateAntiForgeryToken()]
    public async Task<IActionResult> Index(CalculateRequestViewModel request)
    {
      if (this.ModelState.IsValid)
      {
        try
        {
          await calculatorHttpService.CalculateTaxAsync(new CalculateRequest
          {
            PostalCode = request.PostalCode,
            Income = request.Income
          });

          return this.RedirectToAction(nameof(this.History));
        }
        catch (Exception e)
        {
          this.ModelState.AddModelError(string.Empty, e.Message);
        }
      }

      var calculatorViewModel = await this.GetCalculatorViewModelAsync(request);

      return this.View(calculatorViewModel);
    }

    private async Task<CalculatorViewModel> GetCalculatorViewModelAsync(CalculateRequestViewModel? request = null)
    {
      var postalCodes = await calculatorHttpService.GetPostalCodesAsync();
      var calculatorViewModel = new CalculatorViewModel
      {
        PostalCodes = postalCodes,
        Income = request?.Income ?? 0,
        PostalCode = request?.PostalCode ?? string.Empty
      };

      return calculatorViewModel;
    }
  }
}