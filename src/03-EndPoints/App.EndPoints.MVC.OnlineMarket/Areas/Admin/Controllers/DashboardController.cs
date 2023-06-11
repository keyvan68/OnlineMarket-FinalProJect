using App.Domain.Core.Contracts.ApplicationService;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        private readonly IApplicationUserApplicationService _applicationUserApplicationService;
        private readonly IMapper _mapper;


        public DashboardController(IApplicationUserApplicationService applicationUserApplicationService, IMapper mapper)
        {
            _applicationUserApplicationService = applicationUserApplicationService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList(CancellationToken cancellationToken)
        {
            var productList = _mapper.Map<List<ProductViewModel>>(await _applicationUserApplicationService.GetAll(cancellationToken));
            return View(productList);
        }

        public async Task<IActionResult> ConfirmByAdmin(int id)
        {
            await _applicationUserApplicationService.ConfirmByAdmin(id);
            return RedirectToAction(nameof(ProductList));

        }


    }
}
