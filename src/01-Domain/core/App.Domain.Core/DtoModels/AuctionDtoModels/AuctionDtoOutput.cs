using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.AuctionDtoModels
{
    public class AuctionDtoOutput
    {


        public int Id { get; set; }

        public int SellerId { get; set; }

        public int ProductId { get; set; }
        public string StallName { get; set; }
        public string SellerName { get; set; }
        public string ProductName { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int HighestBid { get; set; }

        public bool DeactiveProduct { get; set; }



        public bool IsDeleted { get; set; }


        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual Seller Seller { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
