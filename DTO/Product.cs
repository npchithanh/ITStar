namespace DTO
{
    public class Product : Seo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public int DealPrice { get; set; }
        public string Explain { get; set; }
        public bool IsNewest { get; set; }
        public bool IsHotest { get; set; }

    }
}
