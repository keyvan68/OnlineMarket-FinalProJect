using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface ICommentApplicationService
    {
        Task AddCommentAsync(CommentDto comment, CancellationToken cancellationToken);
        Task DeleteCommentAsync(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAllCommentsAsync(CancellationToken cancellationToken);
        Task<CommentDto> GetCommentByIdAsync(int commentId);
    }
}
