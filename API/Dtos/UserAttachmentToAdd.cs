using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Dtos
{
    public class UserAttachmentToAdd
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}