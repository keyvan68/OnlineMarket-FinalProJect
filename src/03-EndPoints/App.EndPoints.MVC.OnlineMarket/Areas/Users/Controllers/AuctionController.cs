using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "seller")]
    public class AuctionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly IAuctionApplicationService _auctionApplicationService;
        public AuctionController(UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, IAuctionApplicationService auctionApplicationService)
        {
            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _auctionApplicationService = auctionApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CreateAuction(int id)
        {
            AuctionDtoCreate auctionDto = new AuctionDtoCreate
            {
                ProductId = id
            };
            return View(auctionDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuction( int productId, AuctionDtoCreate auctionDto, CancellationToken cancellationToken)
        {
            var UserId = _userManager.GetUserAsync(User).Result.Id;
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(UserId, cancellationToken);
            auctionDto.SellerId = sellerId;
            auctionDto.ProductId = productId;
            await _auctionApplicationService.Create(auctionDto,cancellationToken);
            return RedirectToAction("Index", "Profile");
        }
    }
}
