using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Repositorys;
using App.Domain.Core.DtoModels;
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
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AppDbContext context, IMapper mapper, ILogger<ProductRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(records);
        }

        public async Task<ProductDto> GetById(int productId, CancellationToken cancellationToken)
        {
            var record = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
            return _mapper.Map<ProductDto>(record);
        }

        public async Task<int> Create(ProductDto productDto, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Product>(productDto);

            await _context.Products.AddAsync(record, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return record.Id;

        }

        public async Task Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            var record = await _context.Products.FindAsync(productDto.Id);


            _mapper.Map(productDto, record);


            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task Delete(int productId, CancellationToken cancellationToken)
        {
            var record = await _context.Products.FirstOrDefaultAsync(x=>x.Id==productId);


            _context.Products.Remove(record);

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
