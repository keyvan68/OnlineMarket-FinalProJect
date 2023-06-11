using App.Domain.Core.DtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IStallApplicationService
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
