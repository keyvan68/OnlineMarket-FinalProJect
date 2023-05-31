using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public async Task<IActionResult> SeedData()
        //{

        //    var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("AdminRole"));

        //    var buyerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("BuyerRole"));

        //    var sellerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("SellerRole"));



        //    var adminUserResult = await _userManager.CreateAsync(new ApplicationUser()

        //    {

        //        UserName = "Admin",
        //        Email="keyvan@gmail.com",
        //        EmailConfirmed=true,
        //        NormalizedEmail="KEYVAN@GMAIL.COM",
        //        NormalizedUserName="Admin",
        //        PasswordHash="1234"



        //    });


        //    if (adminUserResult.Succeeded)
        //    {

        //        var adminUser = await _userManager.FindByNameAsync("Admin");

        //        await _userManager.AddToRoleAsync(adminUser, "AdminRole");
        //    }


        //    var testUserResult = await _userManager.CreateAsync(new ApplicationUser()

        //    {

        //        UserName = "test"

        //    });


        //    if (testUserResult.Succeeded)
        //    {

        //        var testUser = await _userManager.FindByNameAsync("test");

        //        await _userManager.AddToRoleAsync(testUser, "BuyerRole");

        //    }


        //    return Ok();


        //}
        public async Task<IActionResult> SeedData()
        {
            var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("AdminRole"));
            var buyerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("BuyerRole"));
            var sellerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("SellerRole"));

            var adminUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "keyvan@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "KEYVAN@GMAIL.COM",
                NormalizedUserName = "Admin"
            };

            var adminUserResult = await _userManager.CreateAsync(adminUser, "1234");

            if (adminUserResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "AdminRole");
            }

            var testUser = new ApplicationUser
            {
                UserName = "test"
            };

            var testUserResult = await _userManager.CreateAsync(testUser, "password");

            if (testUserResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(testUser, "BuyerRole");
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}