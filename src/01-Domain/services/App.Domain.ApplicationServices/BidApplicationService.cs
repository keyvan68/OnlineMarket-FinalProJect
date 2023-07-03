using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.BidDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class BidApplicationService : IBidApplicationService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IBuyerRepository _buyerRepository ;
        private readonly IAuctionRepository _auctionRepository ;
        public BidApplicationService(IBidRepository bidRepository, IBuyerRepository buyerRepository, IAuctionRepository auctionRepository)
        {
            _bidRepository = bidRepository;
            _buyerRepository = buyerRepository;
            _auctionRepository = auctionRepository;
        }
        public async Task<int> Create(CreateBidDto bidDto, CancellationToken cancellationToken)
        {
            var buyer =  await _buyerRepository.GetById(bidDto.BuyerId, cancellationToken);
            var auction = await _auctionRepository.GetById(bidDto.AuctionId, cancellationToken);
            bidDto.BuyerId = buyer.Id;
            bidDto.AuctionId = auction.Id;
            bidDto.CreatedAt = DateTime.Now;
            var list = await _bidRepository.Create(bidDto, cancellationToken);
            return list;
        }

        public async Task Delete(int bidId, CancellationToken cancellationToken)
        {
            await _bidRepository.Delete(bidId, cancellationToken);
        }

        public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _bidRepository.GetAll(cancellationToken);
            return list;
        }

        public async Task<List<BidDto>> GetByAuction(int auctionId, CancellationToken cancellationToken)
        {
            var list = await _bidRepository.GetByAuction(auctionId, cancellationToken);
            return list;
        }

        public async Task<List<BidDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken)
        {
           

            var list = await _bidRepository.GetByBuyer(buyerId, cancellationToken);
            return list;
        }

        public async Task<BidDto> GetById(int bidId, CancellationToken cancellationToken)
        {
            var list = await _bidRepository.GetById(bidId, cancellationToken);
            return list;
        }
       

        //public async Task<List<BidDto>> GetByProduct(int productId, CancellationToken cancellationToken)
        //{
        //    var list = await _bidRepository.GetByProduct(productId, cancellationToken);
        //    return list;
        //}
    }
}
