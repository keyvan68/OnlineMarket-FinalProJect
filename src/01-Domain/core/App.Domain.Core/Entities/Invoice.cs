﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public Guid SellerId { get; set; }

    public Guid BuyerId { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Buyer Buyer { get; set; } = null!;
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

    public virtual Seller Seller { get; set; } = null!;
}
