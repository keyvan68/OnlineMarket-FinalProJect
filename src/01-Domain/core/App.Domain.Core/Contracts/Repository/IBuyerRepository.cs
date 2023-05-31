using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repositorys
{
    public interface IBuyerRepository
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