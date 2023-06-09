﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int BuyerId { get; set; }

    public string Description { get; set; } = null!;

    public bool IsAccepted { get; set; }

    public int InvoiceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }
    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;
}
