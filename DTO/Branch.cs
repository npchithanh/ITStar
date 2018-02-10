using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        [Required]
        public int WardId { get; set; }
    }
}
