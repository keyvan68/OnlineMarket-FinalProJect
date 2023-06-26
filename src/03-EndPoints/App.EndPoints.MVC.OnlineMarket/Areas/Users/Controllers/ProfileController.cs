using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.SellerDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "seller")]
    public class ProfileController : Controller
    {
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, IInvoiceApplicationService invoiceApplicationService, IMapper mapper)
        {

            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _invoiceApplicationService = invoiceApplicationService;
            _mapper = mapper;
        }

       
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var seller = await _sellerApplicationService.GetSellerById(sellerId, cancellationToken);
            var model = new SellerViewmodel()
            {
                Id = sellerId,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Address = seller.Address,
                Birthdate = seller.Birthdate,
                CreatedAt = seller.CreatedAt,
                PhoneNumber = seller.PhoneNumber,
                ImgUrl = seller.ImgUrl
            };

            var invoices = await _invoiceApplicationService.GetInvoicesBySellerId(sellerId, cancellationToken);
            foreach (var invoice in invoices)
            {
                await _invoiceApplicationService.CheckAndUpdateSellerMedal(invoice, cancellationToken);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        { 
            var entity = _mapper.Map<UpdateSellerViewModel>(await _sellerApplicationService.GetSellerById(id, cancellationToken));
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSellerViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _sellerApplicationService.UpdateSeller(_mapper.Map<SellerDto>(model), cancellationToken);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
