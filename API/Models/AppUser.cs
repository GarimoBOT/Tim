using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<Accreditation> Accreditations { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}