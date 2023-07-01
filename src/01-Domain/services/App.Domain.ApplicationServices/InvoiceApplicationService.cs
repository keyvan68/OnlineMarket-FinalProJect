using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Domain.Core.Entities;
using App.Domain.Core.SiteConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class InvoiceApplicationService : IInvoiceApplicationService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISellerApplicationService _sellerApplicationService;
        private readonly Siteconfig _siteConfigs;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoiceApplicationService(IInvoiceRepository invoiceRepository, UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, Siteconfig siteConfigs, IHttpContextAccessor httpContextAccessor)
        {
            _invoiceRepository = invoiceRepository;
            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _siteConfigs = siteConfigs;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CalculateSellerCommisionAmount(int SellerId, CancellationToken cancellationToken)
        {
            var commision = await _invoiceRepository.CalculateSellerSalesAmount(SellerId, cancellationToken);
            return commision;
        }

        public async Task<int> CalculateSellerSalesAmount(int SellerId, CancellationToken cancellationToken)
        {
            var amount = await _invoiceRepository.CalculateSellerSalesAmount(SellerId, cancellationToken);
            return amount;
        }

        public async Task<int> CreateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {

            var invoiceId = await _invoiceRepository.CreateInvoice(invoiceDto, cancellationToken);

            return invoiceId;
        }

        public async Task DeleteInvoice(int invoiceId, CancellationToken cancellationToken)
        {
            await _invoiceRepository.DeleteInvoice(invoiceId, cancellationToken);
        }

        public async Task<List<InvoiceDto>> GetAll(CancellationToken cancellationToken)
        {

            var invoices = await _invoiceRepository.GetAll(cancellationToken);
            var invoiceDtos = new List<InvoiceDto>();

            foreach (var invoice in invoices)
            {
                var amount = await _invoiceRepository.CalculateSellerSalesAmount(invoice.SellerId, cancellationToken);
                var commision = await _invoiceRepository.CalculateSellerCommisionAmount(invoice.SellerId, cancellationToken);

                var invoiceDto = new InvoiceDto
                {
                    Id = invoice.Id,
                    SellerId = invoice.SellerId,
                    TotalAmount = amount - commision,
                    BuyerName = invoice.BuyerName,
                    SellerName = invoice.SellerName,
                    ProductName = invoice.ProductName,
                    Commision = commision,
                    Quantity = invoice.Quantity,
                };

                invoiceDtos.Add(invoiceDto);
                // به‌روزرسانی مقادیر TotalAmount و Commision در دیتابیس
                //invoice.TotalAmount = invoiceDto.TotalAmount;
                //invoice.Commision = invoiceDto.Commision;
                //await _invoiceRepository.UpdateInvoice(invoice, cancellationToken);
            }

            return invoiceDtos;
        }

        public async Task<InvoiceDto> GetInvoiceById(int invoiceId, CancellationToken cancellationToken)
        {
            var id = await _invoiceRepository.GetInvoiceById(invoiceId, cancellationToken);
            return id;
        }

        public async Task<List<InvoiceDto>> GetInvoicesByBuyerAndSeller(int buyerId, int sellerId, CancellationToken cancellationToken)
        {
            var list = await _invoiceRepository.GetInvoicesByBuyerAndSeller(buyerId, sellerId, cancellationToken);
            return list;
        }

        public async Task<List<InvoiceDto>> GetInvoicesByBuyerId(int buyerId, CancellationToken cancellationToken)
        {
            var list = await _invoiceRepository.GetInvoicesByBuyerId(buyerId, cancellationToken);
            return list;
        }

        public async Task<List<InvoiceDto>> GetInvoicesBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var list = await _invoiceRepository.GetInvoicesBySellerId(sellerId, cancellationToken);
            return list;
        }

        public async Task UpdateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            await _invoiceRepository.UpdateInvoice(invoiceDto, cancellationToken);
        }
        public async Task<int> ProcessPayment(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            // ایجاد فاکتور
            var invoiceId = await _invoiceRepository.CreateInvoice(invoiceDto, cancellationToken);
            //var amount = await _invoiceRepository.CalculateSellerSalesAmount(invoiceDto.SellerId, cancellationToken);
            var amount = invoiceDto.TotalAmount * invoiceDto.Quantity;
            // محاسبه مبلغ کارمزد پرداخت به سایت
            int commissionPercentage = _siteConfigs.firstcommision; // درصد کارمزد اولیه
            int commission = (int)(amount * commissionPercentage / 100);


            // بررسی مبلغ فروش و دریافت مدال
            if (invoiceDto.Seller.Medal != null)
            {
                commissionPercentage = _siteConfigs.secondcommision; // درصد کارمزد با مدال
                commission = (int)(amount * commissionPercentage / 100);
            }

            // ذخیره کارمزد در فاکتور
            invoiceDto.Commision = commission;
            invoiceDto.TotalAmount = amount - commission;




            // ذخیره فاکتور با کارمزد
            await _invoiceRepository.UpdateInvoice(invoiceDto, cancellationToken);

            return commission;
        }
        public async Task CheckAndUpdateSellerMedal(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            //var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);          // _siteConfigs.reachprice
            //var sellerId = await _sellerApplicationService.GetSellerIdByApplicationUserId(currentUser.Id, cancellationToken);

            var amount = await _invoiceRepository.CalculateSellerSalesAmount(invoiceDto.SellerId, cancellationToken);
            invoiceDto.TotalAmount = amount;
            if (invoiceDto.TotalAmount >= _siteConfigs.reachprice)
            {
                var seller = await _sellerApplicationService.GetSellerById(invoiceDto.SellerId, cancellationToken);
                if (seller != null && seller.Medal != true)
                {
                    seller.Medal = true;
                    await _sellerApplicationService.UpdateSeller(seller, cancellationToken);
                }
            }
        }
    }
}
