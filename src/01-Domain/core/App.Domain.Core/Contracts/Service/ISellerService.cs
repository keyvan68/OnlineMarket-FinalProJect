using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ISellerService
    {
        Task AddSellerAsync(SellerDto Seller, CancellationToken cancellationToken);
        Task DeleteSellerAsync(int SellerId, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAllSellersAsync(CancellationToken cancellationToken);
        Task<SellerDto> GetSellerByIdAsync(int SellerId);
        Task UpdateSellerAsync(SellerDto Seller, CancellationToken cancellationToken);
    }
}
