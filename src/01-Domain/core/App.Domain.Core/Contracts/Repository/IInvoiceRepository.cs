using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IInvoiceRepository
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