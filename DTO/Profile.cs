using System;

namespace DTO
{
    public class Profile
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; } 
        public bool Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
