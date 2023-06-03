using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        

        public BuyerRepository(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<List<BuyerDto>> GetAll(CancellationToken cancellationToken)
        {
            var buyers = await _dbContext.Buyers
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BuyerDto>>(buyers);
        }
       
        public async Task<BuyerDto> GetById(int buyerId, CancellationToken cancellationToken)
        {
            var buyer = await _dbContext.Buyers
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == buyerId, cancellationToken);

            return _mapper.Map<BuyerDto>(buyer);
        }

        public async Task<int> Create(BuyerDto buyerDto, CancellationToken cancellationToken)
        {
            var buyer = _mapper.Map<Buyer>(buyerDto);


            await _dbContext.Buyers.AddAsync(buyer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return buyer.Id;
        }

        public async Task Update(BuyerDto buyerDto, CancellationToken cancellationToken)
        {
            var existingBuyer = await _dbContext.Buyers
                .FirstOrDefaultAsync(b => b.Id == buyerDto.Id, cancellationToken);

            if (existingBuyer == null)
            {
                throw new InvalidOperationException("Buyer not found.");
            }

            _mapper.Map(buyerDto, existingBuyer);

            _dbContext.Update(existingBuyer);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int buyerId, CancellationToken cancellationToken)
        {
            var buyer = await _dbContext.Buyers
                .FirstOrDefaultAsync(b => b.Id == buyerId, cancellationToken);

            if (buyer != null)
            {
                _dbContext.Buyers.Remove(buyer);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<BuyerDto>> GetByApplicationUser(int applicationUserId, CancellationToken cancellationToken)
        {
            var buyers = await _dbContext.Buyers
                .AsNoTracking()
                .Where(b => b.ApplicationUserId == applicationUserId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BuyerDto>>(buyers);
        }
        public async Task<List<BuyerDto>> GetAllBuyers(CancellationToken cancellationToken)
        {
            var buyers = await _userManager.GetUsersInRoleAsync("buyer");
            return _mapper.Map<List<BuyerDto>>(buyers);
        }
    }
}
