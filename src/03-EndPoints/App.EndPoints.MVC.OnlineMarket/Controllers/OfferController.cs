using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.BidDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class OfferController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBuyerApplicationService _buyerApplicationService;
        private readonly IAuctionApplicationService _auctionApplicationService;
        private readonly IBidApplicationService _bidApplicationService;

        public OfferController(IMapper mapper, UserManager<ApplicationUser> userManager, IBuyerApplicationService buyerApplicationService, IAuctionApplicationService auctionApplicationService, IBidApplicationService bidApplicationService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _buyerApplicationService = buyerApplicationService;
            _auctionApplicationService = auctionApplicationService;
            _bidApplicationService = bidApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var buyerId = await _buyerApplicationService.GetBuyerIdByApplicationUserId(currentUser.Id, cancellationToken);
            var lastPrice = await _auctionApplicationService.LastPriceOfAuction(id, cancellationToken);
            var bidViewModel = new BidViewModel()
            {
                AuctionId = id,
                BuyerId = buyerId,
                Price = lastPrice
            };
            ViewBag.Price = bidViewModel.Price;
            return View(bidViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BidViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var lastPrice = await _auctionApplicationService.LastPriceOfAuction(model.AuctionId, cancellationToken);

                if (model.Price > lastPrice)
                {
                    // سایر عملیات

                    // بروزرسانی مزایده با بیشترین پیشنهاد
                    await _auctionApplicationService.UpdateAuctionWithHighestBid(model.AuctionId,model.Price, cancellationToken);
                    //_mapper.Map<BidDto>(model), cancellationToken
                    // ادامه عملیات
                    await _bidApplicationService.Create(_mapper.Map<CreateBidDto>(model),cancellationToken);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "قیمت پیشنهادی باید از آخرین قیمت مزایده بالاتر باشد");
                }
            }
            return View(model);
        }
    }
}
