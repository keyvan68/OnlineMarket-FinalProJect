using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Stall
{

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; } = null!;
    public string? Address { get; set; } = null!;

    public string? ImageUrl { get; set; }


    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }


    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Seller IdNavigation { get; set; } = null!;
    //public int SellerId { get; set; }
    //public Seller Seller { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
