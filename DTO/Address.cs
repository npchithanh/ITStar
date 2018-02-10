using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public long AccountId { get; set; }
        public string Company { get; set; }
        [Required]
        public int WardId { get; set; }
        public string HouseNumber { get; set; }
        public string Tel { get; set; }
    }
}
