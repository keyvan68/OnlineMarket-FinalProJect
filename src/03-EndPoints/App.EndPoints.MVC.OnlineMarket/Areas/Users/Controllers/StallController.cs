using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.SellerDtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "seller")]
    public class StallController : Controller
    {
        private readonly IStallApplicationService _stallApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public StallController(IStallApplicationService stallApplicationService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _stallApplicationService = stallApplicationService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(CreateStallViewModel stallVM)
        {
            return View(stallVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStallViewModel stallVM , CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {

                stallVM.SellerId = currentUser.Id;
                
                // ساخت غرفه
                await _stallApplicationService.CreateStall(_mapper.Map<CreateStallDto>(stallVM), cancellationToken);
            }

            return View();
        }
    }
}
