using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.BuyerDtoModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "buyer")]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBuyerApplicationService _buyerApplicationService;

        public CustomerController(IMapper mapper, IBuyerApplicationService buyerApplicationService)
        {
            _mapper = mapper;
            _buyerApplicationService = buyerApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateCustomerViewModel>(await _buyerApplicationService.GetById(id, cancellationToken));
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _buyerApplicationService.Update(_mapper.Map<BuyerDto>(model), cancellationToken);
                return RedirectToAction("Index","Profile");
            }
            return View(model);
        }
    }
}
