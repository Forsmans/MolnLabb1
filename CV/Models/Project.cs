using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
