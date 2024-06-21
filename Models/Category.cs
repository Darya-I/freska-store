using System.ComponentModel.DataAnnotations;

namespace Store_microservice.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public List<Subcategory>? Subcategories { get; set; }
    }
}
