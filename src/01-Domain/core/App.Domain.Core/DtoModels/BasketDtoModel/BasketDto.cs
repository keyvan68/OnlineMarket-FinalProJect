using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.BasketDtoModel
{
    public class BasketDto
    {
        public int ProductId { get; set; }
        public int CountOfProducts { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
    }
}
