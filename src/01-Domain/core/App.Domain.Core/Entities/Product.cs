using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public int Status { get; set; }

    public int NumberofProducts { get; set; }

    public int BuyerId { get; set; }

    public int StallId { get; set; }

    public bool? IsAccepted { get; set; }

    public int CategoryId { get; set; }

    //public int? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    //public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    //public int? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

    public virtual Stall Stall { get; set; } = null!;
}
