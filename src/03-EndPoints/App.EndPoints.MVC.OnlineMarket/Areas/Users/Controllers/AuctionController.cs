using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using AutoMapper;
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
        private readonly IProductApplicationService _productApplicationService;
        private readonly IMapper _mapper;
        public AuctionController(UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, IAuctionApplicationService auctionApplicationService, IMapper mapper, IProductApplicationService productApplicationService)
        {
            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _auctionApplicationService = auctionApplicationService;
            _mapper = mapper;
            _productApplicationService = productApplicationService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var productList = _mapper.Map<List<ProductViewModel>>(await _productApplicationService.GetAllWithAuctionBySellerId(sellerId, cancellationToken));
            return View(productList);
        }

        public IActionResult CreateAuction(int id)
        {
            CreateAuctionViewModel viewModel = new CreateAuctionViewModel
            {
                ProductId = id
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuction(int productId, CreateAuctionViewModel model, CancellationToken cancellationToken)
        {
            var UserId = _userManager.GetUserAsync(User).Result.Id;
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(UserId, cancellationToken);
            model.SellerId = sellerId;
            model.ProductId = productId;
            await _auctionApplicationService.Create(_mapper.Map<AuctionDtoCreate>(model), cancellationToken);
            return RedirectToAction("Index", "Profile");
        }
        public async Task<IActionResult> AuctionList(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var auctionList = _mapper.Map<List<AuctionViewModel>>(await _auctionApplicationService.GetAllAuctionBySellerId(sellerId,cancellationToken));
            return View(auctionList);
        }
    }
}
