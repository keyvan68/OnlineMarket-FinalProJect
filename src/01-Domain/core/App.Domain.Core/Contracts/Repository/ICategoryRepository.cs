using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(CategoryDto category, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task UpdateCategoryAsync(CategoryDto category, CancellationToken cancellationToken);
    }
}