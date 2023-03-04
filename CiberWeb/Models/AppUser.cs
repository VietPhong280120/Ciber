using Microsoft.AspNetCore.Identity;

namespace CiberWeb.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
