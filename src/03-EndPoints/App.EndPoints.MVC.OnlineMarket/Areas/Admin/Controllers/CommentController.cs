using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CommentController : Controller
    {
        private readonly ICommentApplicationService _commentApplicationService;
        private readonly IMapper _mapper;


        public CommentController(ICommentApplicationService commentApplicationService, IMapper mapper)
        {
            _commentApplicationService = commentApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CommentList(CancellationToken cancellationToken)
        {
            //var commentList = await _commentApplicationService.GetAll(cancellationToken);
            //return View(commentList);
            var commentList = _mapper.Map<List<CommentViewModel>>(await _commentApplicationService.GetAll(cancellationToken));
            return View(commentList);
        }
        public async Task<IActionResult> ConfirmCommentByAdmin(int id)
        {
            await _commentApplicationService.ConfirmByAdmin(id);
            return RedirectToAction(nameof(CommentList));
        }
    }
}
