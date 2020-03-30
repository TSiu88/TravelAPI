using Microsoft.AspNetCore.Mvc;

namespace TravelApi.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}