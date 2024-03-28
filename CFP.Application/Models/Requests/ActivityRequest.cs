using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CFP.Application.Models.Requests
{
    public class ActivityRequest
    {
        [Required, DataMember(Name = "activity")]
        public string Name { get; set; }
        [Required, DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
