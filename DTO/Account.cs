using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Account
    {
        public long Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public bool IsLocked { get; set; }
        public bool IsApproved { get; set; }

    }
}
