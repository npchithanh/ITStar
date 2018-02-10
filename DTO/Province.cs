using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Province
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
