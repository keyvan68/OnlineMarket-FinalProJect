using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Domain.Core.Entities;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoiceApplicationService(IInvoiceRepository invoiceRepository, UserManager<ApplicationUser> userManager, ISellerApplicationService sellerApplicationService, IHttpContextAccessor httpContextAccessor)
        {
            _invoiceRepository = invoiceRepository;
            _userManager = userManager;
            _sellerApplicationService = sellerApplicationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CalculateSellerSalesAmount(int SellerId, CancellationToken cancellationToken)
        {
          var amount=  await _invoiceRepository.CalculateSellerSalesAmount(SellerId, cancellationToken);
            return amount;
        }

        public async Task<int> CreateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
          var id=  await _invoiceRepository.CreateInvoice(invoiceDto, cancellationToken);
            return id;
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

                var invoiceDto = new InvoiceDto
                {
                    Id = invoice.Id,
                    SellerId = invoice.SellerId,
                    TotalAmount = amount,
                    BuyerName = invoice.BuyerName,
                    SellerName = invoice.SellerName,
                    ProductName = invoice.ProductName,
                    Commision = invoice.Commision,
                    Quantity = invoice.Quantity,
                };

                invoiceDtos.Add(invoiceDto);
            }

            return invoiceDtos;
        }

        public async Task<InvoiceDto> GetInvoiceById(int invoiceId, CancellationToken cancellationToken)
        {
            var id= await _invoiceRepository.GetInvoiceById(invoiceId, cancellationToken);
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
    }
}
