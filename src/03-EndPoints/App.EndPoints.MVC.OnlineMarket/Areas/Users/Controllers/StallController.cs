using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    //[Authorize(Roles = "seller")]
    public class StallController : Controller
    {
        private readonly IStallApplicationService _stallApplicationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StallController(IStallApplicationService stallApplicationService, UserManager<ApplicationUser> userManager)
        {
            _stallApplicationService = stallApplicationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(CreateStallDto stallDto)
        {
            return View(stallDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStallDto stallDto , CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                
                stallDto.SellerId = currentUser.Id;

                // ساخت غرفه
                await _stallApplicationService.CreateStall(stallDto, cancellationToken);
            }

            return View();
        }
    }
}
