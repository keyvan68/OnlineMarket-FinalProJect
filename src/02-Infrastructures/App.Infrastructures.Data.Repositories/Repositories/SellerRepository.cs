using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.SellerDtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public SellerRepository(AppDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<SellerDto> GetSellerById(int sellerId, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FirstOrDefaultAsync(x => x.Id == sellerId,cancellationToken);
            return _mapper.Map<SellerDto>(seller);
        }

        public async Task<int> CreateSeller(CreateSellerDto sellerDto, CancellationToken cancellationToken)
        {
            var seller = _mapper.Map<Seller>(sellerDto);


            await _dbContext.Sellers.AddAsync(seller, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return seller.Id;
        }

        public async Task UpdateSeller(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FirstOrDefaultAsync(x=>x.Id==sellerDto.Id);
            if (seller != null)
            {
                _mapper.Map(sellerDto, seller);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteSeller(int sellerId, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FirstOrDefaultAsync(x => x.Id == sellerId);
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
        public async Task<int> GetCommissionAmountBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == sellerId, cancellationToken);

            if (seller == null)
            {
                // مدیریت خطا در صورت عدم یافتن فروشنده
                throw new Exception("فروشنده مورد نظر یافت نشد.");
            }

            return seller.CommissionAmount;
        }
        public async Task<List<SellerDto>> GetAllSellerWithRole()
        {
            var seller = await _userManager.GetUsersInRoleAsync("seller");
            return _mapper.Map<List<SellerDto>>(seller);
        }
        public async Task<int> GetSellerIdByApplicationUserId(int applicationUserId, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FirstOrDefaultAsync(s => s.ApplicationUserId == applicationUserId, cancellationToken);
            return seller?.Id ?? 0;
        }
        //public string UploadImage(IFormFile file, IWebHostEnvironment webHost)
        //{
        //    var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //    var path = Path.Combine(webHost.WebRootPath, "Images", filename);
        //    using (var stream = File.Create(path))
        //    {
        //        file.CopyTo(stream);
        //    }
        //    return filename;
        //}
    }
}
