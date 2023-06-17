using App.Domain.Core.DtoModels.BidDtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IBidRepository
    {
        Task<int> Create(CreateBidDto bidDto, CancellationToken cancellationToken);
        Task Delete(int bidId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAll(CancellationToken cancellationToken);
        Task<List<BidDto>> GetByAuction(int auctionId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken);
        Task<BidDto> GetById(int bidId, CancellationToken cancellationToken);
        //Task<List<BidDto>> GetByProduct(int productId, CancellationToken cancellationToken);
    }
}