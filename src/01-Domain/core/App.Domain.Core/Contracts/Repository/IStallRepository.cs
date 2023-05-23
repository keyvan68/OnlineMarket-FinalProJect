using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IStallRepository
    {
        Task AddStallAsync(StallDto stall, CancellationToken cancellationToken);
        Task DeleteStallAsync(int stallId, CancellationToken cancellationToken);
        Task<List<StallDto>> GetAllStallsAsync(CancellationToken cancellationToken);
        Task<StallDto> GetStallByIdAsync(int stallId);
        Task UpdateStallAsync(StallDto stall, CancellationToken cancellationToken);
    }
}