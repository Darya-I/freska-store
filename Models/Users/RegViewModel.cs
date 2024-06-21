using System.ComponentModel.DataAnnotations;

namespace Store_microservice.Models.Users
{
    public class RegViewModel
    {
        public string Name { get; set; }
     
        public string Email { get; set; }
     
        public string Password { get; set; }
    }
}
