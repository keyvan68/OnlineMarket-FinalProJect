using App.Domain.Core.DtoModels.BasketDtoModel;
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
        Task<List<InvoiceDto>> GetAll(CancellationToken cancellationToken);
        Task<int> CreateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken);
        Task DeleteInvoice(int invoiceId, CancellationToken cancellationToken);
        Task<InvoiceDto> GetInvoiceById(int invoiceId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetInvoicesByBuyerAndSeller(int buyerId, int sellerId, CancellationToken cancellationToken);
        Task<InvoiceDto> GetInvoicesByBuyerId(int buyerId, CancellationToken cancellationToken);
        Task<List<InvoiceDto>> GetInvoicesBySellerId(int sellerId, CancellationToken cancellationToken);
        Task UpdateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken);

        Task<int> CalculateSellerSalesAmount(int SellerId, CancellationToken cancellationToken);
        Task<int> CalculateSellerCommisionAmount(int SellerId, CancellationToken cancellationToken);
        Task<int> ProcessPayment(InvoiceDto invoiceDto, CancellationToken cancellationToken);
        Task CheckAndUpdateSellerMedal(InvoiceDto invoiceDto, CancellationToken cancellationToken);
        Task CreateBasketFromInvoice(BasketDto basket, CancellationToken cancellationToken);
    }
}
