namespace DTO
{
    public class Attachment
    {
        public int Id { get; set; }
        public int AttachmentTypeId { get; set; }
        public string Url { get; set; }
        public string Alt { get; set; }
        public int? Size { get; set; }
        public string ContentType { get; set; }

    }
}
