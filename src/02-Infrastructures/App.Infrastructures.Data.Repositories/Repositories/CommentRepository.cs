﻿using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.CommentDtoModels;
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

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var records = await _dbContext.Comments
                .Where(x => !x.IsDeleted)
                .Include(b => b.Buyer)
                .Include(i => i.Invoice)
                .ThenInclude(ip => ip.InvoiceProducts)
                .ThenInclude(ip => ip.Product)
                .Include(i => i.Invoice.InvoiceProducts)
                .AsNoTracking()
                .SelectMany(c => c.Invoice.InvoiceProducts, (c, ip) => new { Comment = c, InvoiceProduct = ip })
                .Select(p => new CommentDto
                {
                    Id = p.Comment.Id,
                    BuyerName = p.Comment.Buyer.FirstName + " " + p.Comment.Buyer.LastName,
                    SellerName = p.Comment.Invoice.Seller.FirstName + " " + p.Comment.Invoice.Seller.LastName,
                    ProductName = p.InvoiceProduct.Product.Title,
                    Description = p.Comment.Description,
                    IsAccepted = p.Comment.IsAccepted
                })
                .ToListAsync(cancellationToken);
            return records;
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
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentDto.Id);
            if (comment == null)
                throw new Exception("Comment not found");

            _mapper.Map(commentDto, comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x=>x.Id==commentId);
            if (comment == null)
                throw new Exception("Comment not found");

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CommentDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken)
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
        public async Task ConfirmByAdmin(int id)
        {
            var record = await _dbContext.Comments
            .Where(c => c.Id == id).FirstOrDefaultAsync();
            record.IsAccepted= true;
            await _dbContext.SaveChangesAsync();

        }

    }
}