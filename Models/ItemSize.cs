namespace Store_microservice.Models
{
    public class ItemSize
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }

        public Item Product { get; set; }
        public ClothesSize Size { get; set; }
    }
}
