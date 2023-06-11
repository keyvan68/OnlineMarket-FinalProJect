using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Entities
{

    public class ApplicationUser : IdentityUser<int>
    {
        #region Properties
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        #endregion Properties

        #region Navigation properties

        public Buyer? Buyer { get; set; }
        public Seller? Seller { get; set; }

        #endregion Navigation properties
    }
}
