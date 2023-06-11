using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.InvoiceDtoModels;
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


        public async Task<InvoiceDto> GetInvoiceById(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceId);
            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<int> CreateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return invoice.Id;
        }

        public async Task UpdateInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceDto.Id);
            if (invoice != null)
            {
                _mapper.Map(invoiceDto, invoice);
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

        public async Task<List<InvoiceDto>> GetInvoicesByBuyerId(int buyerId, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices
                .AsNoTracking()
                .Where(i => i.BuyerId == buyerId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<InvoiceDto>>(invoices);
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
    }
}
