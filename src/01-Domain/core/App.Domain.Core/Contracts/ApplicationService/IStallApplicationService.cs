using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IStallApplicationService
    {
        Task AddStallAsync(StallDto stall, CancellationToken cancellationToken);
        Task DeleteStallAsync(int stallId, CancellationToken cancellationToken);
        Task<List<StallDto>> GetAllStallsAsync(CancellationToken cancellationToken);
        Task<StallDto> GetStallByIdAsync(int stallId);
        Task UpdateStallAsync(StallDto stall, CancellationToken cancellationToken);
    }
}
