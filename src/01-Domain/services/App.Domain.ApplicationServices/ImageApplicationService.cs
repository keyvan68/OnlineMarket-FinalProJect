using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repositorys;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class ImageApplicationService : IImageApplicationService
    {
        private readonly IImageRepository _imageRepository;

        public ImageApplicationService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<int> CreateImage(ImageDto imageDto, CancellationToken cancellationToken)
        {
          var id =  await _imageRepository.CreateImage(imageDto, cancellationToken);
            return id;
        }

        public async Task DeleteImage(int imageId, CancellationToken cancellationToken)
        {
            await _imageRepository.DeleteImage(imageId, cancellationToken);
        }

        public async Task<List<ImageDto>> GetImagesByProductId(int productId, CancellationToken cancellationToken)
        {
            var list = await _imageRepository.GetImagesByProductId(productId, cancellationToken);
            return list;
        }

        public async Task UpdateImage(ImageDto imageDto, CancellationToken cancellationToken)
        {
            await _imageRepository.UpdateImage(imageDto, cancellationToken);
        }
    }
}
