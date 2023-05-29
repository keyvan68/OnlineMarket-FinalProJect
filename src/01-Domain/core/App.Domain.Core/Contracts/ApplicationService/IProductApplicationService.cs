using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IProductApplicationService
    {
        Task AddProductAsync(ProductDto Product, CancellationToken cancellationToken);
        Task DeleteProductAsync(int ProductId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<ProductDto> GetProductByIdAsync(int ProductId);
        Task UpdateProductAsync(ProductDto Product, CancellationToken cancellationToken);
    }
}
