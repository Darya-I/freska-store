using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store_microservice.Models
{
    public class Item
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        [ForeignKey("Subcategory")]
        public int FK_SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }

        [ForeignKey("Gender")]
        public int FK_GenderId { get; set; }
        public Gender? Gender { get; set; }

        public List<Image>? Images { get; set; }
        public List<ItemSize>? ItemSizes { get; set; }

        // Добавление связи с CartItem
        public List<CartItem>? CartItems { get; set; }
    }
}
