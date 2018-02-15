namespace DTO
{
    public class Comment
    {
        public int Id { get; set; }
        public long AccountId { get; set; }
        public string FullName { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
    }
}
