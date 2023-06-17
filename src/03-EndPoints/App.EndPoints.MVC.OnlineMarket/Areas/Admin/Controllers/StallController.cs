using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class StallController : Controller
    {
        private readonly IStallApplicationService _stallApplicationService;
        private readonly IMapper _mapper;

        public StallController(IStallApplicationService stallApplicationService, IMapper mapper)
        {
            _stallApplicationService = stallApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var stalls = _mapper.Map<List<StallListViewModel>>(await _stallApplicationService.GetAllStalls(cancellationToken));
            return View(stalls);
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _stallApplicationService.SoftDelete(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            //var user = await _stallApplicationService.GetStallById(id, cancellationToken);
            ////var userVM = _mapper.Map<UpdateUserVM>(user);
            //return View(user);
            var stall = _mapper.Map<UpdateStallViewModels>(await _stallApplicationService.GetStallById(id, cancellationToken));
            return View(stall);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateStallViewModels model, CancellationToken cancellationToken)
        {
            //await _stallApplicationService.UpdateStall(stallDto, cancellationToken);
            //return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {
                await _stallApplicationService.UpdateStall(_mapper.Map<UpdateStallDto>(model), cancellationToken);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
