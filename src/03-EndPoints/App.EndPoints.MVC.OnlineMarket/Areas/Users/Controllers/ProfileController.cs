﻿using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Users")]
        public IActionResult Index()
        {
            return View();
        }
    }
}