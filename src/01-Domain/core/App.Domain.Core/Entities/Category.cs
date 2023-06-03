using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    

    public DateTime? CreatedAt { get; set; }

    

    public DateTime? LastModifiedAt { get; set; }

    
    public string? ImgUrl { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Category> InverseParen { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
