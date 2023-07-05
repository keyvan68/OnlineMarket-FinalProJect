using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.InvoiceDtoModels
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int SellerId { get; set; }

        public int BuyerId { get; set; }
        public string? BuyerName { get; set; } = null!;
        public string? SellerName { get; set; } = null!;
        public string? ProductName { get; set; } = null!;
        public int TotalAmount { get; set; }
        public bool Final { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? Commision { get; set; }

        public int Quantity { get; set; }


        public virtual Buyer Buyer { get; set; } = null!;

        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

        public virtual Seller Seller { get; set; } = null!;
    }
}
