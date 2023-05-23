using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ISellerRepository
    {
        Task AddSellerAsync(SellerDto Seller, CancellationToken cancellationToken);
        Task DeleteSellerAsync(int SellerId, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAllSellersAsync(CancellationToken cancellationToken);
        Task<SellerDto> GetSellerByIdAsync(int SellerId);
        Task UpdateSellerAsync(SellerDto Seller, CancellationToken cancellationToken);
    }
}