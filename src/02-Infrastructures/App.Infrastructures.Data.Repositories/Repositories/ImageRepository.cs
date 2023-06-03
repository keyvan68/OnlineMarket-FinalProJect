using App.Domain.Core.DtoModels;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Contracts.Repository;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public ImageRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ImageDto>> GetImagesByProductId(int productId, CancellationToken cancellationToken)
        {
            var records = await _dbContext.Images
                .AsNoTracking()
                .Where(i => i.ProductId == productId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ImageDto>>(records);
        }

        public async Task<int> CreateImage(ImageDto imageDto, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<Image>(imageDto);
            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return image.Id;
        }

        public async Task UpdateImage(ImageDto imageDto, CancellationToken cancellationToken)
        {
            var image = await _dbContext.Images.FindAsync(imageDto.Id);
            if (image != null)
            {
                _mapper.Map(imageDto, image);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteImage(int imageId, CancellationToken cancellationToken)
        {
            var image = await _dbContext.Images.FindAsync(imageId);
            if (image != null)
            {
                _dbContext.Images.Remove(image);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("image dont exist !!!");
            }
        }
    }
}
