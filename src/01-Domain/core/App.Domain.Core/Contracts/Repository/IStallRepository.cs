
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IStallRepository
    {
        Task<int> CreateStall(StallDto stallDto, CancellationToken cancellationToken);
        Task DeleteStall(int stallId, CancellationToken cancellationToken);
        Task<List<StallDto>> GetAllStalls(CancellationToken cancellationToken);
        Task<UpdateStallDto> GetStallById(int stallId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetStallProducts(int stallId, CancellationToken cancellationToken);
        Task UpdateStall(UpdateStallDto stallDto, CancellationToken cancellationToken);
        Task SoftDelete(int stallId, CancellationToken cancellationToken);
    }
}