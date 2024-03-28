using System.ComponentModel.DataAnnotations;

namespace CFP.Application.Models.Requests
{
    public class ApplicationRequest
    {
        [Required]
        public Guid Author { get; set; }
        public string? Type { get; set; }
        [MinLength(1), MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [MinLength(1), MaxLength(1000)]
        public string? Outline { get; set; }
    }
}
