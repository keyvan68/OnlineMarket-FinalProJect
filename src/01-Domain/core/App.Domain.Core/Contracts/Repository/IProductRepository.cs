using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IProductRepository
    {
        Task AddProductAsync(ProductDto Product, CancellationToken cancellationToken);
        Task DeleteProductAsync(int ProductId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<ProductDto> GetProductByIdAsync(int ProductId);
        Task UpdateProductAsync(ProductDto Product, CancellationToken cancellationToken);
    }
}