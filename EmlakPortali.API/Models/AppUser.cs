using Microsoft.AspNetCore.Identity;

namespace EmlakPortali.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
