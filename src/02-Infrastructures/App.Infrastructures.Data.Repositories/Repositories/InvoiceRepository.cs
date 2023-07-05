using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<InvoiceDto>> GetAll(CancellationToken cancellationToken)
        {
            var records = await _dbContext.Invoices
                .Where(i => i.Final == true)
                .Include(x => x.Buyer)
                .Include(x => x.Seller)
                .Include(ip => ip.InvoiceProducts)
                .ThenInclude(ip => ip.Product)
                .AsNoTracking()
                .SelectMany(i => i.InvoiceProducts, (i, ip) => new { Invoice = i, InvoiceProduct = ip })
                .Select(i => new InvoiceDto
                {
                    Id = i.Invoice.Id,
                    SellerId = i.Invoice.SellerId,
                    BuyerName = i.Invoice.Buyer.FirstName + " " + i.Invoice.Buyer.LastName,
                    SellerName = i.Invoice.Seller.FirstName + " " + i.Invoice.Seller.LastName,
                    ProductName = i.InvoiceProduct.Product.Title,
                    TotalAmount = i.Invoice.TotalAmount,
                    Commision = i.Invoice.Commision,
                    Quantity = i.Invoice.Quantity,

                })
                .ToListAsync(cancellationToken);

            return records;
        }
        public async Task<InvoiceDto> GetInvoiceById(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceId);
            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<int> CreateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            
            var record = new Invoice
            {
                BuyerId=invoiceDto.BuyerId,
                SellerId=invoiceDto.SellerId,
                TotalAmount=invoiceDto.TotalAmount,
                Commision=invoiceDto.Commision,
                Final=invoiceDto.Final,
                CreatedAt=invoiceDto.CreatedAt,
                Quantity=invoiceDto.Quantity,
                InvoiceProducts=invoiceDto.InvoiceProducts
            };
            await _dbContext.Invoices.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return record.Id;
        }
        public async Task<int> CreateInvoiceBasket(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            //var invoice = _mapper.Map<Invoice>(invoiceDto);
            //_dbContext.Invoices.Add(invoice);
            //await _dbContext.SaveChangesAsync(cancellationToken);
            //return invoice.Id;
            var record = new Invoice
            {
                BuyerId = invoiceDto.BuyerId,
                SellerId = invoiceDto.SellerId,
                TotalAmount = invoiceDto.TotalAmount,
                Commision = invoiceDto.Commision,
                Final = invoiceDto.Final,
                CreatedAt = invoiceDto.CreatedAt,
                Quantity = invoiceDto.Quantity,
                InvoiceProducts=invoiceDto.InvoiceProducts
            };
            await _dbContext.Invoices.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return record.Id;
        }

        public async Task UpdateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceDto.Id);
            if (invoice != null)
            {
                invoice.BuyerId = invoiceDto.BuyerId;
                invoice.Commision = invoiceDto.Commision;
                invoice.CreatedAt = invoiceDto.CreatedAt;
                invoice.Quantity = invoiceDto.Quantity;
                invoice.SellerId = invoiceDto.SellerId;
                invoice.TotalAmount = invoiceDto.TotalAmount;
                invoice.Final = invoiceDto.Final;
                invoice.LastModifiedAt = invoiceDto.LastModifiedAt;
                invoice.InvoiceProducts = invoiceDto.InvoiceProducts;
               
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            
        }

        public async Task DeleteInvoice(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceId);
            if (invoice != null)
            {
                _dbContext.Invoices.Remove(invoice);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task softDelete(int id, CancellationToken cancellationToken)
        {
            var record = await _dbContext.Invoices
                .Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
            record.IsDeleted = true;
            record.DeletedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<InvoiceDto>> GetListInvoicesByBuyerId(int buyerId, CancellationToken cancellationToken)
        {
            var records = new List<InvoiceDto>();
            records = await _dbContext.Invoices
                .Where(i => i.BuyerId == buyerId && !i.IsDeleted)
                .Include(i => i.Seller)
                .Include(i => i.InvoiceProducts)
                .ThenInclude(ip => ip.Product)
                .Select(i => new InvoiceDto
                {
                    Id = i.Id,
                    TotalAmount = i.TotalAmount,
                    Commision = i.Commision,
                    BuyerId = i.BuyerId,
                    SellerId = i.SellerId,
                    Final = i.Final,
                    CreatedAt = i.CreatedAt,
                    InvoiceProducts = i.InvoiceProducts,
                    Seller = i.Seller
                }).ToListAsync(cancellationToken);
            return records;
        }
      

        public async Task<List<InvoiceDto>> GetInvoicesBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices
                .AsNoTracking()
                .Where(i => i.SellerId == sellerId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<InvoiceDto>>(invoices);
        }

        public async Task<List<InvoiceDto>> GetInvoicesByBuyerAndSeller(int buyerId, int sellerId, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices
                .AsNoTracking()
                .Where(i => i.BuyerId == buyerId && i.SellerId == sellerId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<InvoiceDto>>(invoices);
        }
        public async Task<int> CalculateSellerSalesAmount(int SellerId, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices
                .Where(i => i.SellerId == SellerId && i.Final == true).ToListAsync(cancellationToken);
            var totalsales = invoices.Sum(i => i.TotalAmount * i.Quantity);

            return totalsales;
        }
        public async Task<int> CalculateSellerCommisionAmount(int SellerId, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices
                .Where(i => i.SellerId == SellerId && i.Final == true).ToListAsync(cancellationToken);
            var totalcommision = invoices.Sum(i => i.Commision *i.Quantity);

            return (int)totalcommision;
        }
        public async Task<List<InvoiceDto>> GetAllByBuyerId(int buyerId, CancellationToken cancellationToken)
        {
            var records = new List<InvoiceDto>();
            records = await _dbContext.Invoices
                .Where(i => i.BuyerId == buyerId && !i.IsDeleted)
                .Include(i => i.Seller)
                .Include(i => i.InvoiceProducts)
                .ThenInclude(ip => ip.Product)
                .Select(i => new InvoiceDto
                {
                    Id = i.Id,
                    TotalAmount = i.TotalAmount,
                    Commision = i.Commision,
                    BuyerId = i.BuyerId,
                    SellerId = i.SellerId,
                    Final = i.Final,
                    CreatedAt = i.CreatedAt,
                    InvoiceProducts = i.InvoiceProducts,
                    Seller = i.Seller
                }).ToListAsync(cancellationToken);
            return records;
        }
        //public async Task<decimal> CalculateSellerSalesAmount(int sellerId, CancellationToken cancellationToken)
        //{
        //    //دریافت فروشنده براساس شناسه
        //    var seller = await _dbContext.Sellers.FirstOrDefaultAsync(s => s.Id == sellerId, cancellationToken);
        //    if (seller == null)
        //    {

        //        throw new Exception("Seller not found");
        //    }

        //    // دریافت لیست فاکتورهای مرتبط با فروشنده
        //    var invoices = await _dbContext.Invoices
        //        .Where(i => i.SellerId == sellerId && i.Final)
        //        .ToListAsync(cancellationToken);

        //    // محاسبه مجموع مبلغ کل فروش
        //    decimal totalSalesAmount = invoices.Sum(i => i.TotalAmount);

        //    // اعمال کمیسیون فروشنده بر روی مجموع فروش
        //    decimal commission = seller.CommissionAmount;
        //    decimal sellerSalesAmount = totalSalesAmount - commission;

        //    return sellerSalesAmount;
        //}

    }
}
