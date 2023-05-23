using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
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



        public async Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId)
        {
            var Entity = await _dbContext.Invoices.FindAsync(invoiceId);
            return _mapper.Map<InvoiceDto>(Entity);
        }

        public async Task<List<InvoiceDto>> GetAllInvoicesAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Invoices.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<InvoiceDto>>(Entity);
        }

        public async Task AddInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Invoice>(invoice);
            _dbContext.Invoices.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Invoices
                .Where(x => x.Id == invoice.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(invoice, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteInvoiceAsync(int invoiceId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Invoices.FindAsync(invoiceId);
            if (onerow != null)
            {
                _dbContext.Invoices.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
