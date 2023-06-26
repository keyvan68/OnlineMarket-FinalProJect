using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISellerApplicationService _sellerApplicationService;

        public ProfileController(UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, IInvoiceApplicationService invoiceApplicationService)
        {

            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _invoiceApplicationService = invoiceApplicationService;
        }

        [Area("Users")]
        [Authorize(Roles = "seller")]
        //[Authorize(Roles = "seller")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var invoices = await _invoiceApplicationService.GetInvoicesBySellerId(sellerId, cancellationToken);
            foreach (var invoice in invoices)
            {
                await _invoiceApplicationService.CheckAndUpdateSellerMedal(invoice, cancellationToken);
            }

            return View();
        }
    }
}
