using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryDto category, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task UpdateCategoryAsync(CategoryDto category, CancellationToken cancellationToken);
    }
}
