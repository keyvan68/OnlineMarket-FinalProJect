using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.BuyerDtoModels;
using App.Domain.Core.DtoModels.SellerDtoModels;
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
            var buyer = await _dbContext.Buyers.FirstOrDefaultAsync(x => x.Id == buyerId, cancellationToken);

            if (buyer == null)
            {
                // مشتری مورد نظر یافت نشد
                return null;
            }

            var buyerDto = new BuyerDto
            {
                Id = buyer.Id,
                FirstName = buyer.FirstName ?? "",
                LastName = buyer.LastName ?? "",
                PhoneNumber = buyer.PhoneNumber ?? "",
                ImgUrl = buyer.ImgUrl ?? "",
                Birthdayte = buyer.Birthdayte,
                Address = buyer.Address ?? "",
                ApplicationUserId = buyer.ApplicationUserId,
                CreatedAt = buyer.CreatedAt,
                LastModifiedAt = buyer.LastModifiedAt,
                IsDeleted = buyer.IsDeleted,
                DeletedAt = buyer.DeletedAt,
                Bids = buyer.Bids.ToList(),
                Comments = buyer.Comments.ToList(),
                ApplicationUser = buyer.ApplicationUser,
                Invoices = buyer.Invoices.ToList()
            };

            return buyerDto;
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
            var Buyer = await _dbContext.Buyers
                .FirstOrDefaultAsync(b => b.Id == buyerDto.Id, cancellationToken);

            if (Buyer != null)
            {

                Buyer.FirstName = buyerDto.FirstName;
                Buyer.LastName = buyerDto.LastName;
                Buyer.Address = buyerDto.Address;
                Buyer.PhoneNumber = buyerDto.PhoneNumber;
                Buyer.Birthdayte = buyerDto.Birthdayte;
                Buyer.LastModifiedAt = buyerDto.LastModifiedAt;

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
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
        public async Task<int> GetBuyerIdByApplicationUserId(int applicationUserId, CancellationToken cancellationToken)
        {
            var buyer = await _dbContext.Buyers.FirstOrDefaultAsync(s => s.ApplicationUserId == applicationUserId, cancellationToken);
            return buyer?.Id ?? 0;
        }
    }
}
