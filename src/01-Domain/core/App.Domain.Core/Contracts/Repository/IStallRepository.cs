
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IStallRepository
    {
        Task<int> CreateStall(CreateStallDto stallDto, CancellationToken cancellationToken);
        Task DeleteStall(int stallId, CancellationToken cancellationToken);
        Task<List<StallDto>> GetAllStalls(CancellationToken cancellationToken);
        Task<UpdateStallDto> GetStallById(int stallId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetStallProducts(int stallId, CancellationToken cancellationToken);
        Task UpdateStall(UpdateStallDto stallDto, CancellationToken cancellationToken);
        Task SoftDelete(int stallId, CancellationToken cancellationToken);
        Task<bool> IsStallExistsForSeller(int sellerId, CancellationToken cancellationToken);
        Task<Stall> GetStallBySellerId(int sellerId, CancellationToken cancellationToken);
    }
}