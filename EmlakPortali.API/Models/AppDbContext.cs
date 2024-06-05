using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmlakPortali.API.Models;

namespace EmlakPortali.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<House> House { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
