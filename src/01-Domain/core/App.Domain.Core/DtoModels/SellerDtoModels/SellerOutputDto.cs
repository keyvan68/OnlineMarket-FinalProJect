using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.SellerDtoModels
{
    public class SellerOutputDto
    {
        public int Id { get; set; }
 
        public string? ImgUrl { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }


        public DateTime Birthdate { get; set; }



    }
}
