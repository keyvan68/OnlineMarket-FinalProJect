using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IInvoiceApplicationService
    {
        Task AddInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken);
        Task DeleteInvoiceAsync(int invoiceId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetAllInvoicesAsync(CancellationToken cancellationToken);
        Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId);
        Task UpdateInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken);
    }
}
