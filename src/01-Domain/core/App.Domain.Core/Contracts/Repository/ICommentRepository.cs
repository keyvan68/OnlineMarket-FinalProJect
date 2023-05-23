using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(CommentDto comment, CancellationToken cancellationToken);
        Task DeleteCommentAsync(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAllCommentsAsync(CancellationToken cancellationToken);
        Task<CommentDto> GetCommentByIdAsync(int commentId);
    }
}