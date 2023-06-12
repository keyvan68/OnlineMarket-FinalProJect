using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.ProductDtoModels
{
    public class CreateProductDto
    {


        public string Title { get; set; } = null!;

        public int Price { get; set; }

        public string Description { get; set; } = null!;


        public int NumberofProducts { get; set; }

        

        public int StallId { get; set; }

        

        public int CategoryId { get; set; }

        public bool Auction { get; set; }
        public DateTime? CreatedAt { get; set; }


        public virtual Category Category { get; set; } = null!;



        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();

        public virtual Stall Stall { get; set; } = null!;
    }
}
