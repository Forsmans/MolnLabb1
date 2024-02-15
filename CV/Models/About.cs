using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string ImagePath { get; set; }

    }
}
