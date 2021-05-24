using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class ApplicationToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameOfUser { get; set; }
        public string Surname { get; set; }
        public string AdminComment { get; set; }
        public bool Approved { get; set; }
        public ICollection<UserAttachmentToReturn> UserAttachments { get; set; }
        
    }
}