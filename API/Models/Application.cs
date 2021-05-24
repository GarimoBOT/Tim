using System.Collections.Generic;

namespace API.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int PatternId { get; set; }
        public AccreditationPattern Pattern { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public string AdminComment { get; set; }
        public bool Approved { get; set; }
        public ICollection<UserAttachment> UserAttachments { get; set; }
    }
}