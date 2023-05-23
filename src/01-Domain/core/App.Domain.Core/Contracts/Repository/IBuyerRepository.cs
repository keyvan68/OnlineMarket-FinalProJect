using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IBuyerRepository
    {
        Task AddBuyerAsync(BuyerDto buyer, CancellationToken cancellationToken);
        Task DeleteBuyerAsync(int buyerId, CancellationToken cancellationToken);
        Task<List<BuyerDto>> GetAllBuyersAsync(CancellationToken cancellationToken);
        Task<BuyerDto> GetbuyerByIdAsync(int buyerId);
        Task UpdateBuyerAsync(BuyerDto buyer, CancellationToken cancellationToken);
    }
}