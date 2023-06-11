using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.BidDtoModels
{
    public class BidDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public int BuyerId { get; set; }

        public int ProductId { get; set; }

        public int AuctionId { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? LastModifiedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual Auction Auction { get; set; } = null!;

        public virtual Buyer Buyer { get; set; } = null!;
    }
}
