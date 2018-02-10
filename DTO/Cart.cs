namespace DTO
{
    public class Cart
    {
        public int Id { get; set; }
        public long CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public int Price { get; set; }
        public int DealPrice { get; set; }

    }
}
