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



        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var Entity = await _dbContext.Categories.FindAsync(categoryId);
            return _mapper.Map<CategoryDto>(Entity);
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Categories.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<CategoryDto>>(Entity);
        }

        public async Task AddCategoryAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Category>(category);
            _dbContext.Categories.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateCategoryAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Categories
                .Where(x => x.Id == category.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(category, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Categories.FindAsync(categoryId);
            if (onerow != null)
            {
                _dbContext.Categories.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
