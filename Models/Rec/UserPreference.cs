using Store_microservice.Data;

namespace Store_microservice.Models.Rec
{
    public class UserPreference
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
