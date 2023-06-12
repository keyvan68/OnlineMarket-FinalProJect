using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.SellerDtoModels
{
    public class CreateSellerDto
    {
        

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        //public string? ImgUrl { get; set; }

        public int CommissionAmount { get; set; }

        public int ApplicationUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

    }
}
