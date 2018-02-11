using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DTO
{
    public class Category : Seo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte Position { get; set; }
        public int? ParentId { get; set; }

        public int? AttachmentId { get; set; }

        public List<Category> Categories { get; set; }

    }
}
