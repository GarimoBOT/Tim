using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ApplicationToAdd
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PatternId { get; set; }
    }
}