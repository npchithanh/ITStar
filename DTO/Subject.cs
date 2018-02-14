using System;
namespace DTO
{
    public class Subject
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int Total { get; set; }
    }
}
