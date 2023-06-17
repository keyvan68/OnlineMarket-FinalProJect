using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class AuctionRepository : IAuctionRepository
    
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuctionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            var auctions = await _context.Auctions
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<AuctionDto>>(auctions);
        }

        public async Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == auctionId, cancellationToken);

            return _mapper.Map<AuctionDto>(auction);
        }
        public async Task<List<AuctionDto>> GetAuctionBySellerId(int sellerID, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions
                .AsNoTracking()
                .Where(a => a.SellerId == sellerID).Include(p=>p.Product.Auction == true).ToListAsync(cancellationToken);

            return _mapper.Map<List<AuctionDto>>(auction);
        }

        public async Task<int> Create(AuctionDtoCreate auctionDto, CancellationToken cancellationToken)
        {
            var record = new Auction
            {
                
                StartTime=auctionDto.StartTime,
                EndTime=DateTime.Now.AddDays(1),
                SellerId=auctionDto.SellerId,
                ProductId=auctionDto.ProductId,
                CreatedAt=auctionDto.CreatedAt,
                HighestBid =auctionDto.HighestBid



            };
            await _context.Auctions.AddAsync(record, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return record.Id;
        }

        public async Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions.FindAsync(auctionDto.Id);



            _mapper.Map(auctionDto, auction);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions.FindAsync(auctionId);



            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<AuctionDto>> GetActiveAuctions(CancellationToken cancellationToken)
        {
            var activeAuctions = await _context.Auctions
                .AsNoTracking()
                .Where(a => a.EndTime > a.StartTime)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<AuctionDto>>(activeAuctions);
        }

        public async Task<int> GetHighestBid(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _context.Auctions
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == auctionId, cancellationToken);

            return auction?.HighestBid ?? 0;
        }
    }
}
