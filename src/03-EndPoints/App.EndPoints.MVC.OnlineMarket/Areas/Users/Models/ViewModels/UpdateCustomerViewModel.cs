namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels
{
    public class UpdateCustomerViewModel
    {
        public int Id { get; set; }

        //public string? ImgUrl { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime? LastModifiedAt { get; set; }


        public DateTime Birthdate { get; set; }
    }
}
