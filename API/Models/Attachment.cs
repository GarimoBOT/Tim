using System.Collections.Generic;

namespace API.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int PatternId { get; set; }
        public AccreditationPattern Pattern { get; set; }
    }
}