using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProductApplicationService productApplicationService, UserManager<ApplicationUser> userManager)
        {
            _productApplicationService = productApplicationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto ,CancellationToken cancellationToken)
        {
            return View();
        }
    }
}
