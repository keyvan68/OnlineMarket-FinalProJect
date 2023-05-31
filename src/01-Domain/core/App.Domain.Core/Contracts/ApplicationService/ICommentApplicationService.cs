using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface ICommentApplicationService
    {
        Task<int> Create(CommentDto commentDto, CancellationToken cancellationToken);
        Task Delete(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAcceptedComments(CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<List<CommentDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken);
        Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetByInvoice(int invoiceId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetRejectedComments(CancellationToken cancellationToken);
        Task Update(CommentDto commentDto, CancellationToken cancellationToken);

        Task ConfirmByAdmin(int id);
    }
}
