using Cybergames.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cybergames
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        // Define your DbSet properties here
        // For example:
        // public DbSet<YourModel> YourModels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";
            
            var clinet = new IdentityRole("client ");
            clinet.NormalizedName = "client";

            builder.Entity<IdentityRole>().HasData(admin,clinet);

        }
    }
}
