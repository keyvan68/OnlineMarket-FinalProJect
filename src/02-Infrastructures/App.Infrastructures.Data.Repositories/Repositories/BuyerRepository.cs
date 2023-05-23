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
    public class BuyerRepository : IBuyerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public BuyerRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BuyerDto> GetbuyerByIdAsync(int buyerId)
        {
            var Entity = await _dbContext.Buyers.FindAsync(buyerId);
            return _mapper.Map<BuyerDto>(Entity);
        }

        public async Task<List<BuyerDto>> GetAllBuyersAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Buyers.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<BuyerDto>>(Entity);
        }

        public async Task AddBuyerAsync(BuyerDto buyer, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Buyer>(buyer);
            _dbContext.Buyers.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateBuyerAsync(BuyerDto buyer, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Buyers
                .Where(x => x.Id == buyer.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(buyer, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteBuyerAsync(int buyerId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Buyers.FindAsync(buyerId);
            if (onerow != null)
            {
                _dbContext.Buyers.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
