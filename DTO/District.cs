using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class District
    {
        public short Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public byte ProvinceId { get; set; }
    }
}
