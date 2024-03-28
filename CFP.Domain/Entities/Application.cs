using System.ComponentModel.DataAnnotations;

namespace CFP.Domain.Entities
{
    public class Application
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Author { get; set; }
        public Guid? Activity { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Outline { get; set; }
        public bool Submitted { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
