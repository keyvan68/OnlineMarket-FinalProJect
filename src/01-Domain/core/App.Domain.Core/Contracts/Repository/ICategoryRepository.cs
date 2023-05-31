using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repositorys
{
    public interface ICategoryRepository
    {
        Task<int> Create(CategoryDto categoryDto, CancellationToken cancellationToken);
        Task Delete(int categoryId, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken);
        Task<CategoryDto> GetParentCategory(int categoryId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetProducts(int categoryId, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetSubcategories(int categoryId, CancellationToken cancellationToken);
        Task Update(CategoryDto categoryDto, CancellationToken cancellationToken);
    }
}