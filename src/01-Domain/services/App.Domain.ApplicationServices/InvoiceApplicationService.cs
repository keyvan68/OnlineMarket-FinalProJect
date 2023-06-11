using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.Entities;
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

        public InvoiceApplicationService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
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
           var invoice= await _invoiceRepository.GetAll(cancellationToken);
            return invoice;
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
