using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Image
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int ProductId { get; set; }

    public string? Url { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
