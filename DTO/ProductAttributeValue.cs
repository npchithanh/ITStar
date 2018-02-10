namespace DTO
{
    public class ProductAttributeValue
    {
        public int ProductId { get; set; }
        public int AttributeValueId { get; set; }
        public byte Position { get; set; }
        public string Explain { get; set; }
        public int? CostDifference { get; set; }
    }
}
