using Store_microservice.Data;

namespace Store_microservice.Models.Rec
{
    
        public class UserCartItem
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public ApplicationUser User { get; set; }
            public int ProductId { get; set; }
            public Item Product { get; set; }
            public int Quantity { get; set; }
            public DateTime AddedAt { get; set; }
        }
 
}
