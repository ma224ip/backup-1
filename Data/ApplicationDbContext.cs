using Cybergames.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cybergames.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "ADMIN";
            
            var client = new IdentityRole("client");
            client.NormalizedName = "CLIENT";

            builder.Entity<IdentityRole>().HasData(admin, client);
        }
    }
}