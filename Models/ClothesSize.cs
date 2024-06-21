using System.ComponentModel.DataAnnotations;

namespace Store_microservice.Models
{
    public class ClothesSize
    {
        [Key]
        public int SizeId { get; set; }
        [MaxLength(30)]
        public string SizeValue { get; set; }

        public List<ItemSize>? Items { get; set; } // Список товаров с этим размером
    }
}
