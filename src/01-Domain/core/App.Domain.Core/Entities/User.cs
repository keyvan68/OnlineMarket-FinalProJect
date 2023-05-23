using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Buyer? Buyer { get; set; }

    public virtual Seller? Seller { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
