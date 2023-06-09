﻿using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Entities;
using App.Domain.Core.utility;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Models;
using App.EndPoints.MVC.OnlineMarket.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IProductApplicationService _productApplicationService;
        private readonly IApplicationUserApplicationService _applicationUserApplicationService;
        private readonly IStallApplicationService _stallApplicationService;
        private readonly IAuctionApplicationService _auctionApplicationService;
        private readonly ICategoryApplicationService _categoryApplicationService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, IProductApplicationService productApplicationService, IMapper mapper, IApplicationUserApplicationService applicationUserApplicationService = null, IStallApplicationService stallApplicationService = null, IAuctionApplicationService auctionApplicationService = null, ICategoryApplicationService categoryApplicationService = null)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _productApplicationService = productApplicationService;
            _mapper = mapper;
            _applicationUserApplicationService = applicationUserApplicationService;
            _stallApplicationService = stallApplicationService;
            _auctionApplicationService = auctionApplicationService;
            _categoryApplicationService = categoryApplicationService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            //var categoriesDTO = await _categoryApplicationService.GetAll(cancellationToken);
            //var categories = CategoryMapper.MapCategories(categoriesDTO);
            //var menuHtml = MenuBuilder.BuildMenu(categories);
            //ViewBag.MenuHtml = menuHtml;
            //***************
            var model = new MultiModelViewModel();
            var productDtos = await _productApplicationService.GetAllWithOutAuction(cancellationToken);
            var auction = await _auctionApplicationService.GetActiveAuctions(cancellationToken);
            var category = await _categoryApplicationService.GetAllParent(cancellationToken);
            var lastSixProducts = productDtos.OrderByDescending(p => p.Id).Take(6);
            var store = await _stallApplicationService.GetAllStalls(cancellationToken);
            var lastSixStall = store.OrderByDescending(s => s.Id).Take(4);
            model.Products = _mapper.Map(lastSixProducts,model.Products);
            model.Auctions = _mapper.Map(auction, model.Auctions);
            model.Stalls = _mapper.Map(lastSixStall, model.Stalls);
            model.Categories = _mapper.Map(category, model.Categories);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> ProductList(CancellationToken cancellationToken)
        {
            var productList = _mapper.Map<List<ProductViewModel>>(await _applicationUserApplicationService.GetAll(cancellationToken));
            return View(productList);

        }
        public async Task<IActionResult> StallList(CancellationToken cancellationToken)
        {
            var stalls = _mapper.Map<List<StallListViewModel>>(await _stallApplicationService.GetAllStalls(cancellationToken));
            return View(stalls);
        }
        public async Task<IActionResult> StallDetails(int id ,CancellationToken cancellationToken)
        {
            var products = await _productApplicationService.GetByStall(id, cancellationToken);

           
            return View(products);

        }
        

        //public async Task<IActionResult> SeedData()
        //{
        //    var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("admin"));
        //    var buyerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("buyer"));
        //    var sellerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("seller"));

        //    var adminUser = new ApplicationUser
        //    {
        //        UserName = "keyvan@gmail.com",
        //        Email = "keyvan@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumber="09121212321",
        //        PhoneNumberConfirmed=true,
        //        NormalizedEmail = "KEYVAN@GMAIL.COM",
        //        NormalizedUserName = "keyvan@gmail.com".ToUpper(),
        //        TwoFactorEnabled= false

        //    };

        //    var adminUserResult = await _userManager.CreateAsync(adminUser, "1234");

        //    if (adminUserResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(adminUser, "admin");
        //    }

        //    var buyerUser = new ApplicationUser
        //    {
        //        UserName = "morteza@gmail.com",
        //        Email = "morteza@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumber = "09121212322",
        //        PhoneNumberConfirmed = true,
        //        NormalizedEmail = "morteza@gmail.com".ToUpper(),
        //        NormalizedUserName = "morteza@gmail.com".ToUpper(),
        //        TwoFactorEnabled = false,
        //        Buyer = new Buyer {FirstName= "morteza",LastName="mohseni",CreatedAt=DateTime.Now,IsDeleted=false
        //        ,PhoneNumber= "09121212322"
        //        }

        //    };

        //    var buyerResult = await _userManager.CreateAsync(buyerUser, "4321");

        //    if (buyerResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(buyerUser, "buyer");
        //    }
        //    var sellerUser = new ApplicationUser
        //    {
        //        UserName = "javad@gmail.com",
        //        Email = "javad@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumber = "09121212329",
        //        PhoneNumberConfirmed = true,
        //        NormalizedEmail = "javad@gmail.com".ToUpper(),
        //        NormalizedUserName = "javad@gmail.com".ToUpper(),
        //        TwoFactorEnabled = false,
        //        Seller = new Seller
        //        {
        //            FirstName = "javad",
        //            LastName = "mohseni",
        //            CreatedAt = DateTime.Now,
        //            IsDeleted = false,
        //            PhoneNumber = "09121212329",
        //            CommissionAmount=10

        //        }

        //    };

        //    var sellerResult = await _userManager.CreateAsync(sellerUser, "2222");

        //    if (sellerResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(sellerUser, "seller");
        //    }

        //    return Ok();
        //}

        //public async Task<IActionResult> SeedData()
        //{
        //    var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("admin"));
        //    var buyerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("buyer"));
        //    var sellerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("seller"));

        //    var adminUser = new ApplicationUser
        //    {
        //        UserName = "keyvan@gmail.com",
        //        Email = "keyvan@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumber="09121212321",
        //        PhoneNumberConfirmed=true,
        //        NormalizedEmail = "KEYVAN@GMAIL.COM",
        //        NormalizedUserName = "keyvan@gmail.com".ToUpper(),
        //        TwoFactorEnabled= false

        //    };

        //    var adminUserResult = await _userManager.CreateAsync(adminUser, "1234");

        //    if (adminUserResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(adminUser, "admin");
        //    }

        //    var buyerUser = new ApplicationUser
        //    {
        //        UserName = "morteza@gmail.com",
        //        Email = "morteza@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumber = "09121212322",
        //        PhoneNumberConfirmed = true,
        //        NormalizedEmail = "morteza@gmail.com".ToUpper(),
        //        NormalizedUserName = "morteza@gmail.com".ToUpper(),
        //        TwoFactorEnabled = false,
        //        Buyer = new Buyer {FirstName= "morteza",LastName="mohseni",CreatedAt=DateTime.Now,IsDeleted=false
        //        ,PhoneNumber= "09121212322"
        //        }

        //    };

        //    var buyerResult = await _userManager.CreateAsync(buyerUser, "4321");

        //    if (buyerResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(buyerUser, "buyer");
        //    }
        //    var sellerUser = new ApplicationUser
        //    {
        //        UserName = "javad@gmail.com",
        //        Email = "javad@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumber = "09121212329",
        //        PhoneNumberConfirmed = true,
        //        NormalizedEmail = "javad@gmail.com".ToUpper(),
        //        NormalizedUserName = "javad@gmail.com".ToUpper(),
        //        TwoFactorEnabled = false,
        //        Seller = new Seller
        //        {
        //            FirstName = "javad",
        //            LastName = "mohseni",
        //            CreatedAt = DateTime.Now,
        //            IsDeleted = false,
        //            PhoneNumber = "09121212329",
        //            CommissionAmount=10

        //        }

        //    };

        //    var sellerResult = await _userManager.CreateAsync(sellerUser, "2222");

        //    if (sellerResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(sellerUser, "seller");
        //    }

        //    return Ok();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}