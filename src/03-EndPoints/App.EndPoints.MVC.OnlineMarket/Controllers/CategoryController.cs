using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly IMapper _mapper;

        public CategoryController(IProductApplicationService productApplicationService, IMapper mapper)
        {
            _productApplicationService = productApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAllProduct(int id ,CancellationToken cancellationToken)
        {
            var productList = _mapper.Map<List<ProductViewModel>>(await _productApplicationService.GetAllProductByCategoryId(id, cancellationToken));
            return View(productList);
            
        }
    }
}
