using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Progress { get; set; }
    }
}
