using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class ApplicationUserApplicationService : IApplicationUserApplicationService
    {
        private readonly IProductRepository _productRepository;
        public ApplicationUserApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ConfirmByAdmin(int id)
        {
            await _productRepository.ConfirmByAdmin(id);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var pruductlist = await _productRepository.GetAll(cancellationToken);
            return pruductlist;
        }
    }
}
