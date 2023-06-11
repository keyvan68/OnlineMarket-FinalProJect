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
   
        public async Task<IActionResult> SeedData()
        {
            var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("admin"));
            var buyerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("buyer"));
            var sellerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("seller"));

            var adminUser = new ApplicationUser
            {
                UserName = "keyvan@gmail.com",
                Email = "keyvan@gmail.com",
                EmailConfirmed = true,
                PhoneNumber="09121212321",
                PhoneNumberConfirmed=true,
                NormalizedEmail = "KEYVAN@GMAIL.COM",
                NormalizedUserName = "keyvan@gmail.com".ToUpper(),
                TwoFactorEnabled= false
                
            };

            var adminUserResult = await _userManager.CreateAsync(adminUser, "1234");

            if (adminUserResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "admin");
            }

            var buyerUser = new ApplicationUser
            {
                UserName = "morteza@gmail.com",
                Email = "morteza@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "09121212322",
                PhoneNumberConfirmed = true,
                NormalizedEmail = "morteza@gmail.com".ToUpper(),
                NormalizedUserName = "morteza@gmail.com".ToUpper(),
                TwoFactorEnabled = false,
                Buyer = new Buyer {FirstName= "morteza",LastName="mohseni",CreatedAt=DateTime.Now,IsDeleted=false
                ,PhoneNumber= "09121212322"
                }

            };

            var buyerResult = await _userManager.CreateAsync(buyerUser, "4321");

            if (buyerResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(buyerUser, "buyer");
            }
            var sellerUser = new ApplicationUser
            {
                UserName = "javad@gmail.com",
                Email = "javad@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "09121212329",
                PhoneNumberConfirmed = true,
                NormalizedEmail = "javad@gmail.com".ToUpper(),
                NormalizedUserName = "javad@gmail.com".ToUpper(),
                TwoFactorEnabled = false,
                Seller = new Seller
                {
                    FirstName = "javad",
                    LastName = "mohseni",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false,
                    PhoneNumber = "09121212329",
                    CommissionAmount=10
                   
                }

            };

            var sellerResult = await _userManager.CreateAsync(sellerUser, "2222");

            if (sellerResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(sellerUser, "seller");
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