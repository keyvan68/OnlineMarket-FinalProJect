using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AuctionDtoModels;
using App.Domain.Core.DtoModels.ImageDtoModels;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.Entities;
using App.Domain.Core.SiteConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class AuctionApplicationService : IAuctionApplicationService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IInvoiceApplicationService _invoiceApplicationService;
        private readonly IBidRepository _bidRepository;
        private readonly Siteconfig _siteConfigs;
        public AuctionApplicationService(IAuctionRepository auctionRepository, IProductRepository productRepository, IInvoiceRepository invoiceRepository, ISellerRepository sellerRepository, Siteconfig siteConfigs, IInvoiceApplicationService invoiceApplicationService, IBidRepository bidRepository)
        {
            _auctionRepository = auctionRepository;
            _productRepository = productRepository;
            _invoiceRepository = invoiceRepository;
            _sellerRepository = sellerRepository;
            _siteConfigs = siteConfigs;
            _invoiceApplicationService = invoiceApplicationService;
            _bidRepository = bidRepository;
        }

        public async Task<int> Create(AuctionDtoCreate auctionDto, CancellationToken cancellationToken)
        {
            auctionDto.CreatedAt = DateTime.Now;
            auctionDto.DeactiveProduct = false;
            //if (auctionDto.StartTime != null)
            //{
            //    auctionDto.EndTime = auctionDto.StartTime.Value.AddMinutes(2);
            //}
            var id = await _auctionRepository.Create(auctionDto, cancellationToken);
            return id;
        }

        public async Task Delete(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionRepository.Delete(auctionId, cancellationToken);
        }

        public async Task<List<AuctionDto>> GetActiveAuctions(CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetActiveAuctions(cancellationToken);
            return list;
        }

        public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetAll(cancellationToken);
            return list;
        }

        public async Task<List<AuctionDtoOutput>> GetAllAuctionBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetAllAuctionBySellerId(sellerId, cancellationToken);
            return list;
        }

        public async Task<List<AuctionDto>> GetAuctionBySellerId(int sellerID, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetAuctionBySellerId(sellerID, cancellationToken);
            return list;
        }
        public async Task<int> LastPriceOfAuction(int auctionId, CancellationToken cancellationToken)
        {
            int price = (await _auctionRepository.GetById(auctionId, cancellationToken)).HighestBid;
            return price;
        }
    

        public async Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetById(auctionId, cancellationToken);
            return list;
        }

        public async Task<int> GetHighestBid(int auctionId, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetHighestBid(auctionId, cancellationToken);
            return list;
        }

        public async Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            await _auctionRepository.Update(auctionDto, cancellationToken);
        }
        public void AuctionOperationTest(int auctionId)
        {
            var x = auctionId + auctionId;

        }
        public async Task AuctionOperation(int auctionId, CancellationToken cancellationToken)
        {
            //get auction
            var auction = await _auctionRepository.GetById(auctionId, cancellationToken);

            //check auction has buyer or not
            if (auction.Bids.Any())
            {

                var winner = auction.Bids.OrderBy(x => x.Price).FirstOrDefault();
                
                //await _auctionRepository.Update(auction,cancellationToken);
                var seller = await _sellerRepository.GetSellerById(auction.SellerId, cancellationToken);



                var invoice = new InvoiceDto()
                {
                    TotalAmount = auction.HighestBid,
                    Commision = Convert.ToInt32(auction.HighestBid - ((seller.CommissionAmount / 100) * auction.HighestBid)),
                    BuyerId = winner.BuyerId,
                    SellerId = seller.Id,
                    CreatedAt = DateTime.Now,
                    Quantity=auction.Product.NumberofProducts,
                    
                };
                await _invoiceApplicationService.ProcessPayment(invoice, cancellationToken);
                


            }
            else
            {
                //disable product 
                var product = await _productRepository.GetById(auction.ProductId, cancellationToken);
                product.IsAccepted = false;
                await _productRepository.Update(product, cancellationToken);
            }
        }

        public async Task<List<AuctionDtoOutput>> GetAllAuctionById(int auctionId, CancellationToken cancellationToken)
        {
            var list = await _auctionRepository.GetAllAuctionById(auctionId, cancellationToken);
            return list;
        }
        public async Task<int> UpdateAuctionWithHighestBid(int auctionId, int price, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepository.GetById(auctionId, cancellationToken);
            var bids = await _bidRepository.GetByAuction(auctionId, cancellationToken);

            if (bids.Count == 0)
            {
                auction.HighestBid = price;
                auction.LastModifiedAt = DateTime.Now;
                await _auctionRepository.Update(auction, cancellationToken);
            }
            else
            {
                var highestBid = price;
                auction.HighestBid = Convert.ToInt32(highestBid);
                auction.LastModifiedAt = DateTime.Now;
                await _auctionRepository.Update(auction, cancellationToken);
            }

            return auction.HighestBid;
        }
    }
}
