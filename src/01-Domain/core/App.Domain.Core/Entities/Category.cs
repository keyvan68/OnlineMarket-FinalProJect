﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParenId { get; set; }

    //public int? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    //public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    //public int? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Category> InverseParen { get; set; } = new List<Category>();

    public virtual Category? Paren { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
