using System;

namespace API.Models
{
    public class Accreditation
    {
        public int Id { get; set; }
        public int PatternId { get; set; }
        public AccreditationPattern Pattern { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime ValidDate { get; set; }
    }
}