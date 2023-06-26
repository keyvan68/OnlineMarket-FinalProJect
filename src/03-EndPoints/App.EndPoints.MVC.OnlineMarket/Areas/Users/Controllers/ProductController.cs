using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.CategoryDtoModels;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using App.Infrastructures.Data.Repositories.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "seller")]
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryApplicationService _categoryApplicationService;
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly IAuctionApplicationService _auctionApplicationService;
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IApplicationUserApplicationService _applicationUserApplicationService;

        public ProductController(IProductApplicationService productApplicationService, UserManager<ApplicationUser> userManager, ICategoryApplicationService categoryApplicationService, ISellerRepository sellerRepository, IMapper mapper, ISellerApplicationService sellerApplicationService, IAuctionApplicationService auctionApplicationService, IInvoiceApplicationService invoiceApplicationService, IWebHostEnvironment hostingEnvironment, IApplicationUserApplicationService applicationUserApplicationService)
        {
            _productApplicationService = productApplicationService;
            _userManager = userManager;
            _categoryApplicationService = categoryApplicationService;
            _mapper = mapper;
            _sellerApplicationService = sellerApplicationService;
            _auctionApplicationService = auctionApplicationService;
            _invoiceApplicationService = invoiceApplicationService;
            _hostingEnvironment = hostingEnvironment;
            _applicationUserApplicationService = applicationUserApplicationService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var productList = _mapper.Map<List<ProductViewModel>>(await _productApplicationService.GetBySeller(sellerId, cancellationToken));
            return View(productList);
        }
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var categoriesList = await _categoryApplicationService.GetAll(cancellationToken);
            var viewModel = new CreateProductViewModel
            {
                Categories = categoriesList
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model, CancellationToken cancellationToken)
        {
            // Get the current user
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);
            // تنظیم شناسه فروشنده در دیتا‌های فرم
            model.StallId = sellerId;
            var productId =  await _productApplicationService.Create(_mapper.Map<CreateProductDto>(model), cancellationToken);
            if (model.ImageFile is not null)
            {

            await _productApplicationService.UploadImageProduct(productId, model.ImageFile, _hostingEnvironment.WebRootPath, cancellationToken);
            }

            return RedirectToAction("Index", "Home");
       

        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _applicationUserApplicationService.SoftDelete(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {

            var product = _mapper.Map<UpdateProductVM>(await _applicationUserApplicationService.GetById(id, cancellationToken));
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM product, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _applicationUserApplicationService.Update(_mapper.Map<UpdateProductDto>(product), cancellationToken);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Test(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            await _invoiceApplicationService.ProcessPayment(invoiceDto, cancellationToken);
            return View();
        }
        

    }
}
