using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.BasketDtoModel;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{

    public class BasketController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBuyerApplicationService _buyerApplicationService;
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly IProductApplicationService _productApplicationService;

        public BasketController(IMapper mapper, UserManager<ApplicationUser> userManager, IBuyerApplicationService buyerApplicationService, IInvoiceApplicationService invoiceApplicationService, IProductApplicationService productApplicationService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _buyerApplicationService = buyerApplicationService;
            _invoiceApplicationService = invoiceApplicationService;
            _productApplicationService = productApplicationService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var buyerId = await _buyerApplicationService.GetBuyerIdByApplicationUserId(currentUser.Id, cancellationToken);
            var basket = await _invoiceApplicationService.GetInvoicesByBuyerId(buyerId, cancellationToken);
            var basketVM = new BasketViewModel();
            _mapper.Map(basket, basketVM);
            return View(basketVM);
        }
        public async Task<IActionResult> AddToBasket(int id, CancellationToken cancellationToken)
        {
            var quantity = (await _productApplicationService.GetById(id, cancellationToken)).NumberofProducts;
            if (quantity > 0)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var buyerId = await _buyerApplicationService.GetBuyerIdByApplicationUserId(currentUser.Id, cancellationToken);
                var basket = await _invoiceApplicationService.GetInvoicesByBuyerId(buyerId, cancellationToken);

                var product = await _productApplicationService.GetSellerIdByProductId(id, cancellationToken);
                if (basket == null)
                {
                    var basketProduct = new BasketDto()
                    {
                        ProductId = id,
                        CountOfProducts = 1,
                        BuyerId = buyerId,
                        SellerId = product.SellerId
                    };
                    await _invoiceApplicationService.CreateBasketFromInvoice(basketProduct, cancellationToken);
                    await _productApplicationService.ReduceQuantityProduct(basketProduct.CountOfProducts, basketProduct.ProductId, cancellationToken);
                    return RedirectToAction("Index", "Basket");
                }
                else
                {
                    if (basket.SellerId == product.SellerId)
                    {
                        var basketProduct = new BasketDto()
                        {
                            ProductId = id,
                            CountOfProducts = 1,
                            BuyerId = basket.BuyerId,
                            SellerId = basket.SellerId
                        };
                        await _invoiceApplicationService.AddProductToBasket(basket, basketProduct, cancellationToken);
                        await _productApplicationService.ReduceQuantityProduct(basketProduct.CountOfProducts, basketProduct.ProductId, cancellationToken);
                        return Redirect(Request.Headers["Referer"].ToString());
                    }
                    else
                    {
                        TempData["SameSellerErrorMessage"] = "از دو غرفه به صورت همزمان نمیتوان خرید کرد";
                        //back tp pervious page
                        return Redirect(Request.Headers["Referer"].ToString());
                    }

                }

            }
            else
            {
                TempData["ProductStockIsZeroErrorMessage"] = "محصول موجود نیست!";
                //back tp pervious page
                return Redirect(Request.Headers["Referer"].ToString());
            }
            
        }
        public async Task<IActionResult> ReduceFromBasket(int id, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var buyerId = await _buyerApplicationService.GetBuyerIdByApplicationUserId(currentUser.Id, cancellationToken);
            var product = await _productApplicationService.GetSellerIdByProductId(id, cancellationToken);
            //reducing product from basket
            var basketDto = new BasketDto()
            {
                ProductId = id,
                CountOfProducts = 1,
                BuyerId = buyerId,
                SellerId = product.SellerId
            };
            await _invoiceApplicationService.reduceProductFromBasket(basketDto, cancellationToken);

            //adding the number of stock products
            await _productApplicationService.AddProductQuantity(basketDto.CountOfProducts, id, cancellationToken);

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> FinalizeFactor(int id, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceApplicationService.GetInvoicesByBuyerId(id, cancellationToken);
            await _invoiceApplicationService.FinalFactor(invoice, cancellationToken);
            return RedirectToAction("Index", "Home");
        }
    }
}
