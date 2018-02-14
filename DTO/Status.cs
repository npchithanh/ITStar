using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
