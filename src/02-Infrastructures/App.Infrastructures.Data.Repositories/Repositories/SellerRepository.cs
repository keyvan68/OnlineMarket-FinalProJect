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
    public class SellerRepository /*: ISellerRepository*/
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SellerRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<SellerDto> GetSellerById(Guid sellerId, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FindAsync(sellerId);
            return _mapper.Map<SellerDto>(seller);
        }

        public async Task<Guid> CreateSeller(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            var seller = _mapper.Map<Seller>(sellerDto);
            seller.Id = Guid.NewGuid();

            await _dbContext.Set<Seller>().AddAsync(seller, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return seller.Id;
        }

        public async Task UpdateSeller(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FindAsync(sellerDto.Id);
            if (seller != null)
            {
                _mapper.Map(sellerDto, seller);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteSeller(Guid sellerId, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FindAsync(sellerId);
            if (seller != null)
            {
                _dbContext.Sellers.Remove(seller);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<SellerDto>> GetAllSellers(CancellationToken cancellationToken)
        {
            var sellers = await _dbContext.Sellers
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<SellerDto>>(sellers);
        }

        public async Task<List<SellerDto>> GetSellersByMedal(int medal, CancellationToken cancellationToken)
        {
            var sellers = await _dbContext.Sellers
                .AsNoTracking()
                .Where(s => s.Medal == medal)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<SellerDto>>(sellers);
        }

        public async Task<List<SellerDto>> GetSellersByCommissionAmount(int commissionAmount, CancellationToken cancellationToken)
        {
            var sellers = await _dbContext.Sellers
                .AsNoTracking()
                .Where(s => s.CommissionAmount == commissionAmount)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<SellerDto>>(sellers);
        }
    }
}
