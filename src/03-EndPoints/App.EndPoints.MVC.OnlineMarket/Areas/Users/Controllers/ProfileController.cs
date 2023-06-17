using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Users")]
        [Authorize(Roles = "seller")]
        //[Authorize(Roles = "seller")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
