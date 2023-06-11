using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.CommentDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class CommentApplicationService : ICommentApplicationService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplicationService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task ConfirmByAdmin(int id)
        {
            await _commentRepository.ConfirmByAdmin(id);
        }

        public async Task<int> Create(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var list = await _commentRepository.Create(commentDto,cancellationToken);
            return list;
        }

        public async Task Delete(int commentId, CancellationToken cancellationToken)
        {
            await _commentRepository.Delete(commentId,cancellationToken);
        }

        public async Task<List<CommentDto>> GetAcceptedComments(CancellationToken cancellationToken)
        {
           var list=  await _commentRepository.GetAcceptedComments(cancellationToken);
            return list;
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _commentRepository.GetAll(cancellationToken);
            return list;
        }

        public async Task<List<CommentDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken)
        {
            var list = await _commentRepository.GetByBuyer(buyerId, cancellationToken);
            return list;
        }

        public async Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken)
        {
            var comment= await _commentRepository.GetById(commentId, cancellationToken);
            return comment;
        }

        public async Task<List<CommentDto>> GetByInvoice(int invoiceId, CancellationToken cancellationToken)
        {
            var list = await _commentRepository.GetByInvoice(invoiceId, cancellationToken);
            return list;
        }

        public async Task<List<CommentDto>> GetRejectedComments(CancellationToken cancellationToken)
        {
            var list = await _commentRepository.GetRejectedComments(cancellationToken);
            return list;
        }

        public async Task Update(CommentDto commentDto, CancellationToken cancellationToken)
        {
            await _commentRepository.Update(commentDto, cancellationToken);
        }
    }
}
