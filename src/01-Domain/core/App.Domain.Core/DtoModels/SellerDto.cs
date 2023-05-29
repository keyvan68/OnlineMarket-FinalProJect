using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class SellerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImgUrl { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public int? CommissionAmount { get; set; }

        public int? Medal { get; set; }

        public Guid ApplicationUserId { get; set; }

        public DateTime Birthdate { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? LastModifiedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        //public ApplicationUser? ApplicationUser { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public virtual Stall? Stall { get; set; }
    }
}
