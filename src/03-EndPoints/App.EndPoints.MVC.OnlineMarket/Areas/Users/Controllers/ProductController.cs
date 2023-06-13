using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.Infrastructures.Data.Repositories.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    //[Authorize(Roles = "seller")]
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryApplicationService _categoryApplicationService;
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly IAuctionApplicationService _auctionApplicationService;
        private readonly IMapper _mapper;

        public ProductController(IProductApplicationService productApplicationService, UserManager<ApplicationUser> userManager, ICategoryApplicationService categoryApplicationService, ISellerRepository sellerRepository, IMapper mapper, ISellerApplicationService sellerApplicationService, IAuctionApplicationService auctionApplicationService)
        {
            _productApplicationService = productApplicationService;
            _userManager = userManager;
            _categoryApplicationService = categoryApplicationService;
            _mapper = mapper;
            _sellerApplicationService = sellerApplicationService;
            _auctionApplicationService = auctionApplicationService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var productList = _mapper.Map<List<ProductViewModel>>(await _productApplicationService.GetBySeller(sellerId, cancellationToken));
            return View(productList);
        }
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var categories = await _categoryApplicationService.GetAll(CancellationToken.None);
            ViewBag.Categories = categories;

            //createProductDto = new CreateProductDto();
            return View(createProductDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto, CancellationToken cancellationToken)
        {
            // Get the current user
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);
            // تنظیم شناسه فروشنده در دیتا‌های فرم
            createProductDto.StallId = sellerId;

            //if (ModelState.IsValid)
            //{


            // Call the Create method in the product application service
            await _productApplicationService.Create(createProductDto, cancellationToken);

            return RedirectToAction("Index", "Home");
            //}

            //var categories = await _categoryApplicationService.GetAll(CancellationToken.None);
            //ViewBag.Categories = categories;

            //return View(createProductDto);

        }
        public async Task<IActionResult> CreateAuction(int id)
        {
            return View();
        }
        public async Task<IActionResult> CreateAuction(int id, CancellationToken cancellationToken)
        {
            

            return RedirectToAction("Index");
        }

    }
}
