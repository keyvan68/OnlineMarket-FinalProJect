﻿using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.StallDtoModels
{
    public class StallDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? SellerName { get; set; }



        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
