using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.AuctionDtoModels
{
    public class AuctionDtoCreate
    {
       

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int HighestBid { get; set; }

        public bool DeactiveProduct { get; set; }

        public DateTime? CreatedAt { get; set; }

        

        public  Seller? Seller { get; set; } = null!;

        public  Product? Product { get; set; } = null!;
    }
}
