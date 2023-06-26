using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.StallDtoModels
{
    public class CreateStallDto
    {

        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public string SellerName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public int SellerId { get; set; } // شناسه فروشنده
        public DateTime? CreatedAt { get; set; }
        public  Seller IdNavigation { get; set; } = null!;

        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
