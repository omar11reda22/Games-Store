using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Games.View_Model
{
    public class RegisterationViewModel
    {
        [Required]
        public string? UserName { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? EMAIL { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string confirmepassword { get; set; } = string.Empty;

    }
}
