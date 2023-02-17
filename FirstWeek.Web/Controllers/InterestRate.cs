using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstWeek.Web.Controllers {
  public class InterestRate : Controller {

    private readonly InterestRateService _interestRateService;

    public InterestRate() {
      _interestRateService = new InterestRateService();
    }
    public IActionResult Index() {
      return View(_interestRateService.GetInterestRate());
    }

    public IActionResult GetInterest(InterestRateVM model) {
      _interestRateService.AddInterestRate(model);
      return RedirectToRoute(new { controller = "InterestRate", action = "Index" });
    }
  }
}
