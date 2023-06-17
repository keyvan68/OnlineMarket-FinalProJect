using App.Domain.Core.Contracts.Repository;
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
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context, IMapper mapper, ILogger<ProductRepository> logger)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        //{
        //    var records = await _context.Products.Include(x => x.Stall)
        //        .AsNoTracking()
        //        .ToListAsync(cancellationToken);
        //    return _mapper.Map<List<ProductDto>>(records);
        //}
        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .Where(a=>a.IsDeleted == false)
                .Include(a=>a.Category)
                .Include(x => x.Stall)
                    .ThenInclude(s => s.IdNavigation) // Load Seller for Stall
                .AsNoTracking()
                .Select(p=> new ProductDto
                {
                    Id=p.Id,
                    Title= p.Title,
                    Price = p.Price,
                    NumberofProducts=p.NumberofProducts,
                    IsAccepted=p.IsAccepted,
                    CategoryName=p.Category.Name,
                    StallName=p.Stall.Name,
                    SellerName = p.Stall.IdNavigation.FirstName + " " + p.Stall.IdNavigation.LastName,
                    Auction=p.Auction
                })
                .ToListAsync(cancellationToken);



            return records;
        }
        public async Task<List<ProductDto>> GetBySeller(int sellerId, CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .Where(a => a.Stall.Id == sellerId && a.IsDeleted == false)
                .Include(a => a.Category)
                .Include(x => x.Stall)
                    .ThenInclude(s => s.IdNavigation)
                .AsNoTracking()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    NumberofProducts = p.NumberofProducts,
                    IsAccepted = p.IsAccepted,
                    CategoryName = p.Category.Name,
                    StallName = p.Stall.Name,
                    SellerName = p.Stall.IdNavigation.FirstName + "" + p.Stall.IdNavigation.LastName,
                    Auction = p.Auction
                })
                .ToListAsync(cancellationToken);

            return records;
        }

        public async Task<UpdateProductDto> GetById(int productId, CancellationToken cancellationToken)
        {
            var record = await _context.Products
                .Where(a => a.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
            return _mapper.Map<UpdateProductDto>(record);
        }
        //public async Task<int> GetProducId(int productId, CancellationToken cancellationToken)
        //{
        //    var record = await _context.Products
        //        .Where(a => a.IsDeleted == false)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
        //    return _mapper.Map<UpdateProductDto>(record);
        //}

        public async Task<int> Create(CreateProductDto productDto, CancellationToken cancellationToken)
        {
            
            var record = new Product
            {
                Title = productDto.Title,
                Description= productDto.Description,
                NumberofProducts = productDto.NumberofProducts,
                CategoryId = productDto.CategoryId,
                StallId = productDto.StallId,
                Auction = productDto.Auction,
                CreatedAt=productDto.CreatedAt,
                Price = productDto.Price,
                Images=productDto.Images,
                
                
                
            };
            await _context.Products.AddAsync(record, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return record.Id;
        }

        public async Task Update(UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var record = await _context.Products.FirstOrDefaultAsync(p=>p.Id == productDto.Id,cancellationToken);
            record.Title = productDto.Title;
            record.NumberofProducts = productDto.NumberofProducts;
            record.Description = productDto.Description;
            record.Price = productDto.Price;
            record.IsAccepted = productDto.IsAccepted;
            record.Auction = productDto.Auction;
            record.LastModifiedAt = DateTime.Now;



            await _context.SaveChangesAsync(cancellationToken);

        }
        


        public async Task Delete(int productId, CancellationToken cancellationToken)
        {
            var record = await _context.Products.FirstOrDefaultAsync(x=>x.Id==productId);


            _context.Products.Remove(record);

            await _context.SaveChangesAsync(cancellationToken);

        }
        public async Task SoftDelete(int productId, CancellationToken cancellationToken)
        {
            var record = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            record.IsDeleted = true;
            record.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

        }
        public async Task<List<ProductDto>> GetByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(records);
        }

        public async Task<List<ProductDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .AsNoTracking()
                .Where(x => x.BuyerId == buyerId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(records);
        }

        public async Task<List<ProductDto>> GetByStall(int stallId, CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .AsNoTracking()
                .Where(x => x.StallId == stallId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(records);
        }

        public async Task<List<ProductDto>> GetAcceptedProducts(CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .AsNoTracking()
                .Where(x => x.IsAccepted == true)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(records);
        }
        public async Task ConfirmByAdmin(int id)
        {
            var record = await _context.Products
            .Where(c => c.Id == id).FirstOrDefaultAsync();
            record.IsAccepted = true;
            await _context.SaveChangesAsync();

        }
    }
}
