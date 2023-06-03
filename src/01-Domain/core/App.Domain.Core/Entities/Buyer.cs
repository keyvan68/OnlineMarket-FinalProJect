using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Buyer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ImgUrl { get; set; }

    public DateTime Birthdayte { get; set; }

    public string? Address { get; set; }

    public int ApplicationUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public ApplicationUser? ApplicationUser { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
