using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Entities
{

    public class ApplicationUser : IdentityUser<int>
    {
        #region Properties

        #endregion Properties

        #region Navigation properties

        public Buyer? Buyer { get; set; }
        public Seller? Seller { get; set; }

        #endregion Navigation properties
    }
}
