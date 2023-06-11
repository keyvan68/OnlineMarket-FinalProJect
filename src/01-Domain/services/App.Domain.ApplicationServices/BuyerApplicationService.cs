using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.BuyerDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class BuyerApplicationService : IBuyerApplicationService
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerApplicationService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<int> Create(BuyerDto buyerDto, CancellationToken cancellationToken)
        {
            var list = await _buyerRepository.Create(buyerDto, cancellationToken);
            return list;
        }

        public async Task Delete(int buyerId, CancellationToken cancellationToken)
        {
            await _buyerRepository.Delete(buyerId, cancellationToken);
        }

        public async Task<List<BuyerDto>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _buyerRepository.GetAll(cancellationToken);
            return list;
        }

        public async Task<List<BuyerDto>> GetAllBuyers(CancellationToken cancellationToken)
        {
            var list = await _buyerRepository.GetAllBuyers(cancellationToken);
            return list;
        }

        public async Task<List<BuyerDto>> GetByApplicationUser(int applicationUserId, CancellationToken cancellationToken)
        {
            var list = await _buyerRepository.GetByApplicationUser(applicationUserId, cancellationToken);
            return list;
        }

        public async Task<BuyerDto> GetById(int buyerId, CancellationToken cancellationToken)
        {
            var buyer = await _buyerRepository.GetById(buyerId, cancellationToken);
            return buyer;
        }

        public async Task Update(BuyerDto buyerDto, CancellationToken cancellationToken)
        {
            await _buyerRepository.Update(buyerDto, cancellationToken);
        }
    }
}
