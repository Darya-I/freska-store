using System.ComponentModel.DataAnnotations;

namespace Store_microservice.Models.Users
{
    public class LoginViewModelcs
    {
        
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
