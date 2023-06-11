using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.CommentDtoModels
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string BuyerName { get; set; } = null!;
        public string SellerName { get; set; } = null!;
        public string? ProductName { get; set; } = null!;

        public string Description { get; set; } = null!;
        public bool? IsAccepted { get; set; }
        public virtual Buyer Buyer { get; set; } = null!;
        public virtual Invoice Invoice { get; set; } = null!;
    }
}
