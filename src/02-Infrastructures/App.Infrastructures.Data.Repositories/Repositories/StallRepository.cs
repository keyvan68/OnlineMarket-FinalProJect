using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Repositorys;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class StallRepository : IStallRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public StallRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<StallDto> GetStallById(int stallId, CancellationToken cancellationToken)
        {
            var record = await _dbContext.Stalls
            .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Id == stallId, cancellationToken);
            return _mapper.Map<StallDto>(record);
        }
   

        public async Task<int> CreateStall(StallDto stallDto, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Stall>(stallDto);
            _dbContext.Stalls.Add(record);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return record.Id;

        }

        public async Task UpdateStall(StallDto stallDto, CancellationToken cancellationToken)
        {
            var record = await _dbContext.Stalls.FirstOrDefaultAsync(x => x.Id == stallDto.Id);
            if (record == null)
                throw new Exception("Comment not found");
            _mapper.Map(stallDto, record);
            await _dbContext.SaveChangesAsync(cancellationToken);
           
        }
       

        public async Task DeleteStall(int stallId, CancellationToken cancellationToken)
        {
            var stall = await _dbContext.Stalls.FirstOrDefaultAsync(x=>x.Id==stallId);
            if (stall != null)
            {
                _dbContext.Stalls.Remove(stall);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<StallDto>> GetAllStalls(CancellationToken cancellationToken)
        {
            var stalls = await _dbContext.Stalls
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<StallDto>>(stalls);
        }

        public async Task<List<ProductDto>> GetStallProducts(int stallId, CancellationToken cancellationToken)
        {
            var stall = await _dbContext.Stalls.FirstOrDefaultAsync(x => x.Id == stallId, cancellationToken);
            if (stall != null)
            {
                var products = stall.Products.ToList();
                var productDtos = _mapper.Map<List<ProductDto>>(products); 
                return productDtos;
            }

            return new List<ProductDto>();
        }
    }
}
