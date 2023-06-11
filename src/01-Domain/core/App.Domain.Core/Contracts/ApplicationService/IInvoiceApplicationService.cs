using App.Domain.Core.DtoModels.InvoiceDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IInvoiceApplicationService
    {
        Task<int> CreateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken);
        Task DeleteInvoice(int invoiceId, CancellationToken cancellationToken);
        Task<InvoiceDto> GetInvoiceById(int invoiceId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetInvoicesByBuyerAndSeller(int buyerId, int sellerId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetInvoicesByBuyerId(int buyerId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetInvoicesBySellerId(int sellerId, CancellationToken cancellationToken);
        Task UpdateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken);
    }
}
