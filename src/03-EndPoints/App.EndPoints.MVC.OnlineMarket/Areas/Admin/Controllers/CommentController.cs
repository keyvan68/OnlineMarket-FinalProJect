using App.Domain.Core.Contracts.ApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class CommentController : Controller
    {
        private readonly ICommentApplicationService _commentApplicationService;

        public CommentController(ICommentApplicationService commentApplicationService)
        {
            _commentApplicationService = commentApplicationService;
        }

        public async Task<IActionResult> CommentList(CancellationToken cancellationToken)
        {
            var commentList = await _commentApplicationService.GetAll(cancellationToken);
            return View(commentList);
        }
        public async Task<IActionResult> ConfirmCommentByAdmin(int id)
        {
            await _commentApplicationService.ConfirmByAdmin(id);
            return RedirectToAction(nameof(CommentList));
        }
    }
}
