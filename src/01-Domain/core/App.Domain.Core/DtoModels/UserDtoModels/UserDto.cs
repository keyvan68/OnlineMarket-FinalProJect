using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.DtoModels.UserDtoModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? ConfirmPassword { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        #region Navigation properties

        public Buyer? Buyer { get; set; }
        public Seller? Seller { get; set; }
        public Admin? Admin { get; set; }

        #endregion Navigation properties
    }
}