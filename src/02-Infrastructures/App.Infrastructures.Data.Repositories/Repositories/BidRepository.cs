﻿using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.BidDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
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

        public async Task<int> Create(CreateBidDto bidDto, CancellationToken cancellationToken)
        {
            var record = new Bid
            {
                Description = bidDto.Description,
                Price=bidDto.Price,
                BuyerId=bidDto.BuyerId,
                AuctionId=bidDto.AuctionId,
                CreatedAt=bidDto.CreatedAt
            };
            await _dbContext.Bids.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return record.Id;
           
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

        //public async Task<List<BidDto>> GetByProduct(int productId, CancellationToken cancellationToken)
        //{
        //    var bids = await _dbContext.Bids
        //        .AsNoTracking()
        //        .Where(b => b.ProductId == productId)
        //        .ToListAsync(cancellationToken);

        //    return _mapper.Map<List<BidDto>>(bids);
        //}

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
