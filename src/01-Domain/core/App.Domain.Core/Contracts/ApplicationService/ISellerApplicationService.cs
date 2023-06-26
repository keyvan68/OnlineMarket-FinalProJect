using App.Domain.Core.DtoModels.SellerDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface ISellerApplicationService
    {
        Task<int> CreateSeller(CreateSellerDto sellerDto, CancellationToken cancellationToken);
        Task DeleteSeller(int sellerId, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAllSellers(CancellationToken cancellationToken);
        Task<SellerDto> GetSellerById(int sellerId, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetSellersByCommissionAmount(int commissionAmount, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetSellersByMedal(bool medal, CancellationToken cancellationToken);
        Task UpdateSeller(SellerDto sellerDto, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAllSellerWithRole();

        Task<int> GetSellerIdByApplicationUserId(int applicationUserId, CancellationToken cancellationToken);
    }
}
