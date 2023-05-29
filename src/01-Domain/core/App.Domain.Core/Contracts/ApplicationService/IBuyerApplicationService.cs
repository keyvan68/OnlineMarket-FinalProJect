using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IBuyerApplicationService
    {
        Task AddBuyerAsync(BuyerDto buyer, CancellationToken cancellationToken);
        Task DeleteBuyerAsync(int buyerId, CancellationToken cancellationToken);
        Task<List<BuyerDto>> GetAllBuyersAsync(CancellationToken cancellationToken);
        Task<BuyerDto> GetbuyerByIdAsync(int buyerId);
        Task UpdateBuyerAsync(BuyerDto buyer, CancellationToken cancellationToken);
    }
}
