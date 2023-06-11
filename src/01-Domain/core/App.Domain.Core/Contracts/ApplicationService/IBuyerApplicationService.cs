using App.Domain.Core.DtoModels.BuyerDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IBuyerApplicationService
    {
        Task<int> Create(BuyerDto buyerDto, CancellationToken cancellationToken);
        Task Delete(int buyerId, CancellationToken cancellationToken);
        Task<List<BuyerDto>> GetAll(CancellationToken cancellationToken);
        Task<List<BuyerDto>> GetByApplicationUser(int applicationUserId, CancellationToken cancellationToken);
        Task<BuyerDto> GetById(int buyerId, CancellationToken cancellationToken);
        Task Update(BuyerDto buyerDto, CancellationToken cancellationToken);
        Task<List<BuyerDto>> GetAllBuyers(CancellationToken cancellationToken);
    }
}
