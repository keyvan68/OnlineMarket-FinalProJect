using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryApplicationService _categoryApplicationService;
        private readonly ISellerRepository _sellerRepository;

        public ProductController(IProductApplicationService productApplicationService, UserManager<ApplicationUser> userManager, ICategoryApplicationService categoryApplicationService, ISellerRepository sellerRepository)
        {
            _productApplicationService = productApplicationService;
            _userManager = userManager;
            _categoryApplicationService = categoryApplicationService;
            _sellerRepository = sellerRepository;
        }

        public IActionResult Index()
        {
            return View();
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
            var sellerId = await _sellerRepository.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);
            // تنظیم شناسه فروشنده در دیتا‌های فرم
            createProductDto.StallId = sellerId;

            //if (ModelState.IsValid)
            //{


                // Call the Create method in the product application service
                await _productApplicationService.Create(createProductDto, cancellationToken);

                return RedirectToAction("Index", "Home");
            //}

            var categories = await _categoryApplicationService.GetAll(CancellationToken.None);
            ViewBag.Categories = categories;

            return View(createProductDto);

        }
    }
}
