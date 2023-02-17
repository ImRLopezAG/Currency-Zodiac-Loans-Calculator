using Application.Services;
using Application.ViewModels;
using FirstWeek.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstWeek.Web.Controllers {
  public class CurrencyController : Controller {
    private readonly CurrencyService _currencyService;

    public CurrencyController() {
      _currencyService = new CurrencyService();
    }
    public IActionResult Index() {
      return View(_currencyService.GetCurrency());
    }

    [HttpPost]

    public IActionResult GetConvertion(CurrencyVM model) {
      _currencyService.AddCurrency(model);
      return RedirectToRoute(new { controller = "Currency", action = "Index" });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
