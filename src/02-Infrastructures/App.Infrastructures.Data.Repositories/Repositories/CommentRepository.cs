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
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommentDto> GetCommentByIdAsync(int commentId)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<List<CommentDto>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Comments.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<CommentDto>>(comments);
        }



        public async Task AddCommentAsync(CommentDto comment, CancellationToken cancellationToken)
        {
            var commentEntity = _mapper.Map<Comment>(comment);
            _dbContext.Comments.Add(commentEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task DeleteCommentAsync(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}