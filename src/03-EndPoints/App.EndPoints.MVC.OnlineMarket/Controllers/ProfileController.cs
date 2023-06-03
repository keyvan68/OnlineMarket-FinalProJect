using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
