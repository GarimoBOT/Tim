using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class AccreditationToAdd
    {
        [Required]
        public int PatternId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime ValidDate { get; set; }
    }
}