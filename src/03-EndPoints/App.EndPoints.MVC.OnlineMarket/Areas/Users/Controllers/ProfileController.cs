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
    
    public class ProfileController : Controller
    {
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly IBuyerApplicationService _buyerApplicationService;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, IInvoiceApplicationService invoiceApplicationService, IMapper mapper, IBuyerApplicationService buyerApplicationService)
        {

            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _invoiceApplicationService = invoiceApplicationService;
            _mapper = mapper;
            _buyerApplicationService = buyerApplicationService;
        }
        [Authorize(Roles = "seller,buyer")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);
            var buyerId = await _buyerApplicationService.GetBuyerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var model = new ProfileViewModel();

            if (sellerId != 0)
            {
                var seller = await _sellerApplicationService.GetSellerById(sellerId, cancellationToken);
                model.Seller = new SellerViewmodel()
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
            }
            else if (buyerId != 0)
            {
                var buyer = await _buyerApplicationService.GetById(buyerId, cancellationToken);
                model.Buyer = new BuyerViewModel()
                {
                    Id = buyerId,
                    FirstName = buyer.FirstName,
                    LastName = buyer.LastName,
                    Address = buyer.Address,
                    Birthdate = buyer.Birthdayte,
                    CreatedAt = buyer.CreatedAt,
                    PhoneNumber = buyer.PhoneNumber,
                    ImgUrl = buyer.ImgUrl
                };
            }

            return View(model);
        }
        //public async Task<IActionResult> Index(CancellationToken cancellationToken)
        //{
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);
        //    var buyerId = await _buyerApplicationService.GetBuyerIdByApplicationUserId(currentUser.Id, cancellationToken);

        //    var seller = await _sellerApplicationService.GetSellerById(sellerId, cancellationToken);
        //    var buyer = await _buyerApplicationService.GetById(buyerId, cancellationToken);
        //    var model = new SellerViewmodel()
        //    {
        //        Id = sellerId,
        //        FirstName = seller.FirstName,
        //        LastName = seller.LastName,
        //        Address = seller.Address,
        //        Birthdate = seller.Birthdate,
        //        CreatedAt = seller.CreatedAt,
        //        PhoneNumber = seller.PhoneNumber,
        //        ImgUrl = seller.ImgUrl
        //    };

        //    var invoices = await _invoiceApplicationService.GetInvoicesBySellerId(sellerId, cancellationToken);
        //    foreach (var invoice in invoices)
        //    {
        //        await _invoiceApplicationService.CheckAndUpdateSellerMedal(invoice, cancellationToken);
        //    }

        //    return View(model);
        //}
        [Authorize(Roles = "seller")]
        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        { 
            var entity = _mapper.Map<UpdateSellerViewModel>(await _sellerApplicationService.GetSellerById(id, cancellationToken));
            return View(entity);
        }
        [Authorize(Roles = "seller")]
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
