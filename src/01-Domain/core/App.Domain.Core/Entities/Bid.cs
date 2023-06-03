using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Bid
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public int BuyerId { get; set; }

    public int ProductId { get; set; }

    public int AuctionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Buyer Buyer { get; set; } = null!;
}
