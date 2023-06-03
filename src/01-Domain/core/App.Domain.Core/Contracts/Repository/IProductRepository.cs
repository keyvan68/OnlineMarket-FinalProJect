using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IProductRepository
    {
        Task<int> Create(ProductDto productDto, CancellationToken cancellationToken);
        Task Delete(int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAcceptedProducts(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetByCategory(int categoryId, CancellationToken cancellationToken);
        Task<ProductDto> GetById(int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetByStall(int stallId, CancellationToken cancellationToken);
        Task Update(ProductDto productDto, CancellationToken cancellationToken);
        Task ConfirmByAdmin(int id);
    }
}