using System.ComponentModel.DataAnnotations;

namespace CiberWeb.ViewModel
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

    }
}
