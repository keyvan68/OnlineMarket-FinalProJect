using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.SellerDtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "seller")]
    public class SellerController : Controller
    {
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SellerController(ISellerApplicationService sellerApplicationService, UserManager<ApplicationUser> userManager)
        {
            _sellerApplicationService = sellerApplicationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> Create(CreateSellerDto sellerDto)
        //{
            
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(CreateSellerDto sellerDto, CancellationToken cancellationToken)
        //{
        //    var userId = _userManager.GetUserId(User); // دریافت شناسه کاربر فعلی
        //    sellerDto.ApplicationUserId = int.Parse(userId); // تبدیل شناسه کاربر به int و مقداردهی به فیلد ApplicationUserId

        //    await _sellerApplicationService.CreateSeller(sellerDto, cancellationToken);
        //    return View();
        //}

    }
}
