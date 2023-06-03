using App.Domain.Core.Contracts.ApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IApplicationUserApplicationService _applicationUserApplicationService;

        public DashboardController(IApplicationUserApplicationService applicationUserApplicationService)
        {
            _applicationUserApplicationService = applicationUserApplicationService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList(CancellationToken cancellationToken)
        {
            var productList = await _applicationUserApplicationService.GetAll(cancellationToken);
            return View(productList);
        }
        
        public async Task<IActionResult> ConfirmByAdmin(int id)
        {
            await _applicationUserApplicationService.ConfirmByAdmin(id);
            //return RedirectToAction("ProductList", "Dashboard", new { area = "Admin" });
            return RedirectToAction(nameof(ProductList));

        }
    }
}
