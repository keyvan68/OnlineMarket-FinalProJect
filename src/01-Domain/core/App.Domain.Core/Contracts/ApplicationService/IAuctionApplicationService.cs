using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IAuctionApplicationService
    {
        Task AddAuctionAsync(AuctionDto auction, CancellationToken cancellationToken);
        Task DeleteAuctionAsync(int auctionId, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAllAuctionsAsync(CancellationToken cancellationToken);
        Task<AuctionDto> GetAuctionByIdAsync(int auctionId);
        Task UpdateAuctionAsync(AuctionDto auction, CancellationToken cancellationToken);
    }
}
