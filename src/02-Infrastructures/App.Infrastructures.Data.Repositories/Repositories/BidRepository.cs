using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Repositorys;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public BidRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            var bids = await _dbContext.Bids
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BidDto>>(bids);
        }

        public async Task<BidDto> GetById(int bidId, CancellationToken cancellationToken)
        {
            var bid = await _dbContext.Bids
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == bidId, cancellationToken);

            return _mapper.Map<BidDto>(bid);
        }

        public async Task<int> Create(BidDto bidDto, CancellationToken cancellationToken)
        {
            var bid = _mapper.Map<Bid>(bidDto);

            _dbContext.Bids.Add(bid);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return bid.Id;
        }

        public async Task Delete(int bidId, CancellationToken cancellationToken)
        {
            var bid = await _dbContext.Bids.FindAsync(bidId);
            if (bid != null)
            {
                _dbContext.Bids.Remove(bid);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<BidDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken)
        {
            var bids = await _dbContext.Bids
                .AsNoTracking()
                .Where(b => b.BuyerId == buyerId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BidDto>>(bids);
        }

        public async Task<List<BidDto>> GetByProduct(int productId, CancellationToken cancellationToken)
        {
            var bids = await _dbContext.Bids
                .AsNoTracking()
                .Where(b => b.ProductId == productId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BidDto>>(bids);
        }

        public async Task<List<BidDto>> GetByAuction(int auctionId, CancellationToken cancellationToken)
        {
            var bids = await _dbContext.Bids
                .AsNoTracking()
                .Where(b => b.AuctionId == auctionId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BidDto>>(bids);
        }
    }
}
