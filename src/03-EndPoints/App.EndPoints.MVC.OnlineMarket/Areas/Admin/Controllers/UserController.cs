using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IApplicationUserApplicationService _applicationUserApplicationService;
        private readonly IMapper _mapper;

        public UserController(IApplicationUserApplicationService applicationUserApplicationService, IMapper mapper)
        {
            _applicationUserApplicationService = applicationUserApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            var UserList = _mapper.Map<List<UserViewModels>>(await _applicationUserApplicationService.GetUserAll(cancellationToken));
            return View(UserList);
        }
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserViewModels>(await _applicationUserApplicationService.GetUserById(id, cancellationToken));
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModels model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _applicationUserApplicationService.UpdateUser(_mapper.Map<UserDto>(model), cancellationToken);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _applicationUserApplicationService.DeleteUser(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
