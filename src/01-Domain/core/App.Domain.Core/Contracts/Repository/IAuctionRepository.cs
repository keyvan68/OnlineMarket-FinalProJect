﻿using App.Domain.Core.DtoModels.AuctionDtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAuctionRepository
    {
        Task<int> Create(AuctionDtoCreate auctionDto, CancellationToken cancellationToken);
        Task Delete(int auctionId, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetActiveAuctions(CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken);
        Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken);
        Task<int> GetHighestBid(int auctionId, CancellationToken cancellationToken);
        Task Update(AuctionDto auctionDto, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAuctionBySellerId(int sellerID, CancellationToken cancellationToken);
        Task<List<AuctionDtoOutput>> GetAllAuctionBySellerId(int sellerId, CancellationToken cancellationToken);
        Task<List<AuctionDtoOutput>> GetAllAuctionById(int auctionId, CancellationToken cancellationToken);

    }
}