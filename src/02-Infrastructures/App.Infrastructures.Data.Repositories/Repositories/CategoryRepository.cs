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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            var categories = await _dbContext.Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<int> Create(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(categoryDto);

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return category.Id;
        }

        public async Task Update(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x=>x.Id==categoryDto.Id);

            if (existingCategory == null)
                throw new Exception("Category not found");

            _mapper.Map(categoryDto, existingCategory);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int categoryId, CancellationToken cancellationToken)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

            if (existingCategory == null)
                throw new Exception("Category not found");

            _dbContext.Categories.Remove(existingCategory);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CategoryDto>> GetSubcategories(int categoryId, CancellationToken cancellationToken)
        {
            var subcategories = await _dbContext.Categories
                .AsNoTracking()
                .Where(c => c.ParentId == categoryId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<CategoryDto>>(subcategories);
        }

        public async Task<CategoryDto> GetParentCategory(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

            if (category == null || category.ParentId == null)
                return null;

            var parentCategory = await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == category.ParentId, cancellationToken);

            return _mapper.Map<CategoryDto>(parentCategory);
        }

        public async Task<List<ProductDto>> GetProducts(int categoryId, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Categories
                .AsNoTracking()
                .Include(c => c.Products)
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.Products)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
