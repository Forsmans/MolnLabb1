using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
