using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class OfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
