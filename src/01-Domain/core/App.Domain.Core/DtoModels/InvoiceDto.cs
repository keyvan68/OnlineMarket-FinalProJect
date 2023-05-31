﻿using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public int BuyerId { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? LastModifiedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;

        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

        public virtual Seller Seller { get; set; } = null!;
    }
}
