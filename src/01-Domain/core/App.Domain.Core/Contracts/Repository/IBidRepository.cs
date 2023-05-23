using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IBidRepository
    {
        Task AddBidAsync(BidDto bid, CancellationToken cancellationToken);
        Task DeleteBidAsync(int bidId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAllBidsAsync(CancellationToken cancellationToken);
        Task<BidDto> GetBidByIdAsync(int bidId);
        Task UpdateBidAsync(BidDto bid, CancellationToken cancellationToken);
    }
}