using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repositorys
{
    public interface IStallRepository
    {
        Task<int> CreateStall(StallDto stallDto, CancellationToken cancellationToken);
        Task DeleteStall(int stallId, CancellationToken cancellationToken);
        Task<List<StallDto>> GetAllStalls(CancellationToken cancellationToken);
        Task<StallDto> GetStallById(int stallId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetStallProducts(int stallId, CancellationToken cancellationToken);
        Task UpdateStall(StallDto stallDto, CancellationToken cancellationToken);
    }
}