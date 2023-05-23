using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IInvoiceRepository
    {
        Task AddInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken);
        Task DeleteInvoiceAsync(int invoiceId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetAllInvoicesAsync(CancellationToken cancellationToken);
        Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId);
        Task UpdateInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken);
    }
}