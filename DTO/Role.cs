using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Explain { get; set; }
    }
}
