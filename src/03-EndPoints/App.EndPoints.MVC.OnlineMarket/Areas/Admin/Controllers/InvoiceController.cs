using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceApplicationService invoiceApplicationService, IMapper mapper)
        {
            _invoiceApplicationService = invoiceApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            var InvoiceList = _mapper.Map<List<InvoiceViewModel>>(await _invoiceApplicationService.GetAll(cancellationToken));
            return View(InvoiceList);
            
        }
    }
}
