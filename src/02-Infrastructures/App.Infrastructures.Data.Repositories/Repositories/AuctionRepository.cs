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
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuctionRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<AuctionDto> GetAuctionByIdAsync(int auctionId)
        {
            var Entity = await _dbContext.Auctions.FindAsync(auctionId);
            return _mapper.Map<AuctionDto>(Entity);
        }

        public async Task<List<AuctionDto>> GetAllAuctionsAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Auctions.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<AuctionDto>>(Entity);
        }

        public async Task AddAuctionAsync(AuctionDto auction, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Auction>(auction);
            _dbContext.Auctions.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateAuctionAsync(AuctionDto auction, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Auctions
                .Where(x => x.Id == auction.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(auction, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteAuctionAsync(int auctionId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Auctions.FindAsync(auctionId);
            if (onerow != null)
            {
                _dbContext.Auctions.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
