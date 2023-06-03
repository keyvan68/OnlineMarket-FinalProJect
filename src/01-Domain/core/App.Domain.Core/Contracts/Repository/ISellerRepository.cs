using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ISellerRepository
    {
        Task<int> CreateSeller(SellerDto sellerDto, CancellationToken cancellationToken);
        Task DeleteSeller(int sellerId, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAllSellers(CancellationToken cancellationToken);
        Task<SellerDto> GetSellerById(int sellerId, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetSellersByCommissionAmount(int commissionAmount, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetSellersByMedal(int medal, CancellationToken cancellationToken);
        Task UpdateSeller(SellerDto sellerDto, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAllSellerWithRole();
    }
}