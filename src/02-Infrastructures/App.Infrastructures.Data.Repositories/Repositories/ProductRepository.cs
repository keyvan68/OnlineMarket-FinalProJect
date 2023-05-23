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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        public async Task<ProductDto> GetProductByIdAsync(int ProductId)
        {
            var Entity = await _dbContext.Products.FindAsync(ProductId);
            return _mapper.Map<ProductDto>(Entity);
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Products.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(Entity);
        }

        public async Task AddProductAsync(ProductDto Product, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Product>(Product);
            _dbContext.Products.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateProductAsync(ProductDto Product, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Products
                .Where(x => x.Id == Product.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(Product, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteProductAsync(int ProductId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Products.FindAsync(ProductId);
            if (onerow != null)
            {
                _dbContext.Products.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
