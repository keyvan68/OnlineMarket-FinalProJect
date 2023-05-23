using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAuctionRepository
    {
        Task AddAuctionAsync(AuctionDto auction, CancellationToken cancellationToken);
        Task DeleteAuctionAsync(int auctionId, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAllAuctionsAsync(CancellationToken cancellationToken);
        Task<AuctionDto> GetAuctionByIdAsync(int auctionId);
        Task UpdateAuctionAsync(AuctionDto auction, CancellationToken cancellationToken);
    }
}