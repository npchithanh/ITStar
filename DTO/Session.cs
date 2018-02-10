using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Session
    {
        public string Id { get; set; }
        [Required]
        public long AccountId { get; set; }
        [Required]
        public string IP { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }

    }
}
