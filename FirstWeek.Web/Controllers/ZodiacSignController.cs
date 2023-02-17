using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstWeek.Web.Controllers {
  public class ZodiacSignController : Controller {
    private readonly ZodiacService _zodiacService;

    public ZodiacSignController() {
      _zodiacService = new ZodiacService();
    }
    public IActionResult Index() {
      return View(_zodiacService.GetZodiac());
    }

    [HttpPost]
    public IActionResult GetZodiac(ZodiacVM model) {
      _zodiacService.AddZodiac(model);
      return RedirectToRoute(new { controller = "ZodiacSign", action = "Index" });
    }
  }
}
