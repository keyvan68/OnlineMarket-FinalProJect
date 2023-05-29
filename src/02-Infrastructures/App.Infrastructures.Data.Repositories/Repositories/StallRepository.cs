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
    public class StallRepository /*: IStallRepository*/
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public StallRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Stall> GetStallById(Guid stallId, CancellationToken cancellationToken)
        {
            var stall = await _dbContext.Stalls.FindAsync(stallId);
            return stall;
        }

        public async Task<Guid> CreateStall(Stall stall, CancellationToken cancellationToken)
        {
            _dbContext.Stalls.Add(stall);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return stall.Id;
        }

        public async Task UpdateStall(Stall stall, CancellationToken cancellationToken)
        {
            _dbContext.Stalls.Update(stall);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStall(Guid stallId, CancellationToken cancellationToken)
        {
            var stall = await _dbContext.Stalls.FindAsync(stallId);
            if (stall != null)
            {
                _dbContext.Stalls.Remove(stall);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<Stall>> GetAllStalls(CancellationToken cancellationToken)
        {
            var stalls = await _dbContext.Stalls
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return stalls;
        }

        public async Task<List<Product>> GetStallProducts(Guid stallId, CancellationToken cancellationToken)
        {
            var stall = await _dbContext.Stalls.FindAsync(stallId);
            if (stall != null)
            {
                var products = stall.Products.ToList();
                return products;
            }
            return new List<Product>();
        }
    }
}
