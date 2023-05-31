using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class CommentDto
    {
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public string Description { get; set; } = null!;

        public int InvoiceId { get; set; }

        public bool? IsAccepted { get; set; }

       

        public int? DeletedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? LastModifiedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;

        public virtual Invoice Invoice { get; set; } = null!;
    }
}
