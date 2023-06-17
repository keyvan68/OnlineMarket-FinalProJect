using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class AuctionApplicationService : IAuctionApplicationService
    {
        private readonly IAuctionRepository _auctionRepository;
        public AuctionApplicationService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<int> Create(AuctionDtoCreate auctionDto, CancellationToken cancellationToken)
        {
            auctionDto.CreatedAt = DateTime.Now;
            var id = await _auctionRepository.Create(auctionDto, cancellationToken);
            return id;
        }

        public async Task Delete(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionRepository.Delete(auctionId, cancellationToken);
        }

        public async Task<List<AuctionDto>> GetActiveAuctions(CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetActiveAuctions(cancellationToken);
            return list;
        }

        public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetAll(cancellationToken);
            return list;
        }

        public async Task<List<AuctionDto>> GetAuctionBySellerId(int sellerID, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetAuctionBySellerId(sellerID, cancellationToken);
            return list;
        }

        public async Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetById(auctionId, cancellationToken);
            return list;
        }

        public async Task<int> GetHighestBid(int auctionId, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetHighestBid(auctionId, cancellationToken);
            return list;
        }

        public async Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            await _auctionRepository.Update(auctionDto, cancellationToken);
        }
    }
}
