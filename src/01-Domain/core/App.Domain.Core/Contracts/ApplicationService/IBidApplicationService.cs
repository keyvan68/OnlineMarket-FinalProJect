using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IBidApplicationService
    {
        Task AddBidAsync(BidDto bid, CancellationToken cancellationToken);
        Task DeleteBidAsync(int bidId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAllBidsAsync(CancellationToken cancellationToken);
        Task<BidDto> GetBidByIdAsync(int bidId);
        Task UpdateBidAsync(BidDto bid, CancellationToken cancellationToken);
    }
}
