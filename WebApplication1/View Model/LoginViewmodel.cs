using System.ComponentModel.DataAnnotations;

namespace Games.View_Model
{
    public class LoginViewmodel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool RemmemberMe { get; set; }

    }
}
