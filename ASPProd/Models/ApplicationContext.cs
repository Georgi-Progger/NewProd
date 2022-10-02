using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ASPProd.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Place> Places { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole {Name = "Admin"}
            );
        }
    }
}
