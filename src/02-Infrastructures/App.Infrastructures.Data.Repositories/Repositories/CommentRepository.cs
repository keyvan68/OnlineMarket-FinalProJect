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
    public class CommentRepository /*: ICommentRepository*/
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public CommentRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var records = await _dbContext.Comments
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<CommentDto>>(records);
        }

        public async Task<CommentDto> GetById(int commentId, CancellationToken cancellationToken)
        {
            var record = await _dbContext.Comments
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == commentId, cancellationToken);
            return _mapper.Map<CommentDto>(record);
        }

        public async Task<int> Create(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }

        public async Task Update(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.Comments.FindAsync(commentDto.Id);
            if (comment == null)
                throw new Exception("Comment not found");

            _mapper.Map(commentDto, comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            if (comment == null)
                throw new Exception("Comment not found");

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CommentDto>> GetByBuyer(Guid buyerId, CancellationToken cancellationToken)
        {
            var records = await _dbContext.Comments
                .AsNoTracking()
                .Where(c => c.BuyerId == buyerId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<CommentDto>>(records);
        }

        public async Task<List<CommentDto>> GetByInvoice(int invoiceId, CancellationToken cancellationToken)
        {
            var records = await _dbContext.Comments
                .AsNoTracking()
                .Where(c => c.InvoiceId == invoiceId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<CommentDto>>(records);
        }
        public async Task<List<CommentDto>> GetAcceptedComments(CancellationToken cancellationToken)
        {
            var records = await _dbContext.Comments
                .AsNoTracking()
                .Where(c => c.IsAccepted == true)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<CommentDto>>(records);
        }

        public async Task<List<CommentDto>> GetRejectedComments(CancellationToken cancellationToken)
        {
            var records = await _dbContext.Comments
                .AsNoTracking()
                .Where(c => c.IsAccepted == false)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<CommentDto>>(records);
        }

    }
}