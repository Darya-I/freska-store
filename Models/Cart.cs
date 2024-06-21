using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store_microservice.Data;

namespace Store_microservice.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime CreatedDate { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}
