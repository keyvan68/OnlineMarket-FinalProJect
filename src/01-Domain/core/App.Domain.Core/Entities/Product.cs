using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public  class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;


    public int NumberofProducts { get; set; }

    public int BuyerId { get; set; }

    public int StallId { get; set; }

    public bool IsAccepted { get; set; }

    public int CategoryId { get; set; }

    public bool Auction { get; set; }
    public DateTime? CreatedAt { get; set; }


    public DateTime? LastModifiedAt { get; set; }


    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

    public virtual Stall Stall { get; set; } = null!;
}
