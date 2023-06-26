using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Seller
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ImgUrl { get; set; }

    public int CommissionAmount { get; set; }

    public bool? Medal { get; set; }
    //public bool? MedalAmount { get; set; }

    

    public int ApplicationUserId { get; set; }

    public DateTime Birthdate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    
    public virtual Stall? Stall { get; set; }
}
