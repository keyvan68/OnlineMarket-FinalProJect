﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.ProductDtoModels
{
    public class ProductDtoSeller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellerId { get; set; }
    }
}
