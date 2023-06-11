using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.DtoModels.ProductDtoModels
{
    public class UpdateProductDto
    {
        public int? Id { get; set; }

        public string Title { get; set; } = null!;
        public int NumberofProducts { get; set; }
        public string Description { get; set; } = null!;
        public bool IsAccepted { get; set; }
        public bool Auction { get; set; }
        public int Price { get; set; }
        //public DateTime? LastModifiedAt { get; set; }

    }
}
