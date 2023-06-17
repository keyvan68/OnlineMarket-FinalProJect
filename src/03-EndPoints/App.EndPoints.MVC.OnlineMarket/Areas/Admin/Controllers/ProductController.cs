using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {

        private readonly IApplicationUserApplicationService _applicationUserApplicationService;
        private readonly IMapper _mapper;

        public ProductController(IApplicationUserApplicationService applicationUserApplicationService, IMapper mapper)
        {
            _applicationUserApplicationService = applicationUserApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ProductList(CancellationToken cancellationToken)
        {
            var productList = _mapper.Map<List<ProductViewModel>>(await _applicationUserApplicationService.GetAll(cancellationToken));
            return View(productList);
            //var productList = await _applicationUserApplicationService.GetAll(cancellationToken);
            ////var products = _mapper.Map<List<ProductViewModel>>(await _applicationUserApplicationService.GetAll(cancellationToken));
            //return View(productList);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _applicationUserApplicationService.SoftDelete(id, cancellationToken);
            return RedirectToAction(nameof(ProductList));
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
            return RedirectToAction("ProductList");
        }
    }
}
