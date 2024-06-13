using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities
{
    public class User
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
