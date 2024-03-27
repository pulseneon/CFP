using System.ComponentModel.DataAnnotations;

namespace CFP.Domain.Entities
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
