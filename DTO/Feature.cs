using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Controller { get; set; }

        public string Action { get; set; }
        public string Url { get; set; }
    }
}
