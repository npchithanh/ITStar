namespace DTO
{
    public class Cart : SubjectDetail
    {
        public int Id { get; set; }
        public long CartId { get; set; }
        public int DealPrice { get; set; }
    }
}
