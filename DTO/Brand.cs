using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte Position { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}
