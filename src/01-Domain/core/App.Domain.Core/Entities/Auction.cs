using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Auction
{
    public int Id { get; set; }

    public int SellerId { get; set; }

    public int ProductId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int HighestBid { get; set; }

    public bool? DeactiveProduct { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Seller Seller { get; set; } = null!;
}
