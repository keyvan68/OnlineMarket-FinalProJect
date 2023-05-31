using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IImageApplicationService
    {
        Task<int> CreateImage(ImageDto imageDto, CancellationToken cancellationToken);
        Task DeleteImage(int imageId, CancellationToken cancellationToken);
        Task<List<ImageDto>> GetImagesByProductId(int productId, CancellationToken cancellationToken);
        Task UpdateImage(ImageDto imageDto, CancellationToken cancellationToken);
    }
}
