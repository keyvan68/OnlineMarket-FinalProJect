using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class UpdateStallViewModels
    {
        public int Id { get; set; }
        [Display(Name ="نام مغازه")]
        public string Name { get; set; } = null!;

    }
}
