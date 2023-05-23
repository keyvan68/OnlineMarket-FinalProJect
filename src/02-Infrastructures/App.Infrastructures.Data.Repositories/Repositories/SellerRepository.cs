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
    public class SellerRepository : ISellerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SellerRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<SellerDto> GetSellerByIdAsync(int SellerId)
        {
            var Entity = await _dbContext.Sellers.FindAsync(SellerId);
            return _mapper.Map<SellerDto>(Entity);
        }

        public async Task<List<SellerDto>> GetAllSellersAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Sellers.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<SellerDto>>(Entity);
        }

        public async Task AddSellerAsync(SellerDto Seller, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Seller>(Seller);
            _dbContext.Sellers.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateSellerAsync(SellerDto Seller, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Sellers
                .Where(x => x.Id == Seller.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(Seller, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteSellerAsync(int SellerId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Sellers.FindAsync(SellerId);
            if (onerow != null)
            {
                _dbContext.Sellers.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
