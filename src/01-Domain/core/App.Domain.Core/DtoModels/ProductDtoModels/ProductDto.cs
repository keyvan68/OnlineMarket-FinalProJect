using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.DtoModels.ProductDtoModels;

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int NumberofProducts { get; set; }

    public bool IsAccepted { get; set; }

    public string? CategoryName { get; set; }

    public string? SellerName { get; set; }

    public string? StallName { get; set; }

    public virtual Category Category { get; set; } = null!;

    //public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    //public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

    public virtual Stall Stall { get; set; } = null!;
}
