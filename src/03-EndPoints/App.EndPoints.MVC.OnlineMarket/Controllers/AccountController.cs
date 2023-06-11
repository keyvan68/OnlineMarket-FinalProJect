using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.AccountDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApplicationService _accountApplicationService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IAccountApplicationService accountApplicationService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountApplicationService=accountApplicationService;
            _mapper=mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)

            {

                await _signInManager.SignOutAsync();

                return RedirectToAction("Login");

            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountApplicationService.Login(_mapper.Map<LoginUserDto>(model));
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (roles.Contains("buyer") || roles.Contains("seller"))
                    {
                        return RedirectToAction("Index", "Profile");
                    }
                  

                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }
        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {

                var result = await _accountApplicationService.Register(_mapper.Map<RegisterUserDto>(model));
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Privacy", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

       
    }
}
