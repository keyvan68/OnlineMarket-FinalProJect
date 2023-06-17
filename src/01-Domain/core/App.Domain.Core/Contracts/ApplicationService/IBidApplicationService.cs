using App.Domain.Core.DtoModels.BidDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IBidApplicationService
    {
        Task<int> Create(CreateBidDto bidDto, CancellationToken cancellationToken);
        Task Delete(int bidId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAll(CancellationToken cancellationToken);
        Task<List<BidDto>> GetByAuction(int auctionId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken);
        Task<BidDto> GetById(int bidId, CancellationToken cancellationToken);
        //Task<List<BidDto>> GetByProduct(int productId, CancellationToken cancellationToken);
    }
}
