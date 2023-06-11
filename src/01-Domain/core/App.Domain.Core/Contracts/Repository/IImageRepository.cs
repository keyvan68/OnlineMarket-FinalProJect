using App.Domain.Core.DtoModels.ImageDtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IImageRepository
    {
        Task<int> CreateImage(ImageDto imageDto, CancellationToken cancellationToken);
        Task DeleteImage(int imageId, CancellationToken cancellationToken);
        Task<List<ImageDto>> GetImagesByProductId(int productId, CancellationToken cancellationToken);
        Task UpdateImage(ImageDto imageDto, CancellationToken cancellationToken);
    }
}