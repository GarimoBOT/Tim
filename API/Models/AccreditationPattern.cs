using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class AccreditationPattern
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Accreditation> Accreditations { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}