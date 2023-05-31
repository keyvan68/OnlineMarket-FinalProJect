using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    //public class BidService : IBidApplicationService
    //{
    //    private readonly IBidRepository _bidRepository;

    //    public BidService(IBidRepository bidRepository)
    //    {
    //        _bidRepository = bidRepository;
    //    }
        
    //    public async Task AddBidAsync(BidDto bid, CancellationToken cancellationToken)
    //    {
    //        await _bidRepository.AddBidAsync(bid, cancellationToken);
    //    }

    //    public async Task DeleteBidAsync(int bidId, CancellationToken cancellationToken)
    //    {
    //        await _bidRepository.DeleteBidAsync(bidId, cancellationToken);  
    //    }

    //    public async Task<List<BidDto>> GetAllBidsAsync(CancellationToken cancellationToken)
    //    {
    //        var bid= await _bidRepository.GetAllBidsAsync(cancellationToken);
    //        return bid;
    //    }

    //    public Task<BidDto> GetBidByIdAsync(int bidId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task UpdateBidAsync(BidDto bid, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
