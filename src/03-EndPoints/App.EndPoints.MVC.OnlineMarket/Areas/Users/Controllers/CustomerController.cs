using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
