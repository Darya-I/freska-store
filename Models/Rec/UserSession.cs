

using Store_microservice.Data;

namespace Store_microservice.Models.Rec
{
    public class UserSession
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SessionInfo { get; set; }
    }
}
