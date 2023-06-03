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
    public class SellerApplicationService : ISellerApplicationService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerApplicationService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<int> CreateSeller(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            var sellerId=await _sellerRepository.CreateSeller(sellerDto,cancellationToken);
            return sellerId;
        }

        public async Task DeleteSeller(int sellerId, CancellationToken cancellationToken)
        {
            await _sellerRepository.DeleteSeller(sellerId,cancellationToken);
        }

        public async Task<List<SellerDto>> GetAllSellerWithRole()
        {
            var sellerlistrole = await _sellerRepository.GetAllSellerWithRole();
            return sellerlistrole;
        }

        public async Task<List<SellerDto>> GetAllSellers(CancellationToken cancellationToken)
        {
            var sellerList = await _sellerRepository.GetAllSellers(cancellationToken);
            return sellerList;
        }

        public async Task<SellerDto> GetSellerById(int sellerId, CancellationToken cancellationToken)
        {
            var seller= await _sellerRepository.GetSellerById(sellerId, cancellationToken);
            return seller;
        }

        public async Task<List<SellerDto>> GetSellersByCommissionAmount(int commissionAmount, CancellationToken cancellationToken)
        {
            var sellerlist = await _sellerRepository.GetSellersByCommissionAmount(commissionAmount, cancellationToken);
            return sellerlist;
        }

        public async Task<List<SellerDto>> GetSellersByMedal(int medal, CancellationToken cancellationToken)
        {
            var medalListSeller= await _sellerRepository.GetSellersByMedal(medal, cancellationToken);
            return medalListSeller;
        }

        public async Task UpdateSeller(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            await _sellerRepository.UpdateSeller(sellerDto, cancellationToken);
        }
    }
}
