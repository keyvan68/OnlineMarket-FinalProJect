using App.Domain.Core.Contracts.Repository;
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



        public async Task<BidDto> GetBidByIdAsync(int bidId)
        {
            var Entity = await _dbContext.Bids.FindAsync(bidId);
            return _mapper.Map<BidDto>(Entity);
        }

        public async Task<List<BidDto>> GetAllBidsAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Bids.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<BidDto>>(Entity);
        }

        public async Task AddBidAsync(BidDto bid, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Bid>(bid);
            _dbContext.Bids.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateBidAsync(BidDto bid, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Bids
                .Where(x => x.Id == bid.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(bid, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteBidAsync(int bidId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Bids.FindAsync(bidId);
            if (onerow != null)
            {
                _dbContext.Bids.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
