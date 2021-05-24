using System;

namespace API.Dtos
{
    public class AccreditationToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ValidDate { get; set; }
        public int PatternId { get; set; }
        public int UserId { get; set; }
        public string NameOfUser { get; set; }
        public string Surname { get; set; }

    }
}