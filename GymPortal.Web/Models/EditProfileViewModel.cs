using System.ComponentModel.DataAnnotations;

namespace GymPortal.Web.Models
{
    public class EditProfileViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}