using App.Domain.Core.DtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IProductRepository
    {
        Task<int> Create(CreateProductDto productDto, CancellationToken cancellationToken);
        Task Delete(int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAcceptedProducts(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetBySeller(int sellerId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetByCategory(int categoryId, CancellationToken cancellationToken);
        Task<UpdateProductDto> GetById(int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetByStall(int stallId, CancellationToken cancellationToken);
        Task Update(UpdateProductDto productDto, CancellationToken cancellationToken);
        Task ConfirmByAdmin(int id);
        Task SoftDelete(int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllWithAuctionBySellerId(int sellerId, CancellationToken cancellationToken);
        Task<ProductDtoSeller> GetSellerIdByProductId(int id, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProductByCategoryId(int categoryId, CancellationToken cancellationToken);
    }
}