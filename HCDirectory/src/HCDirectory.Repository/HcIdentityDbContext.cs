using HCDirectory.Repository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace HCDirectory.Repository
{
    public class HcIdentityDbContext : IdentityDbContext<HcdentityUser, HcIdentityRole, string>
    {
        public HcIdentityDbContext
       (DbContextOptions<HcIdentityDbContext> options)
        : base(options)
        {
        }

        public DbSet<HcIdentityRole> HcIdentityRoles { get; set; }
        public DbSet<HcdentityUser> HcIdentityUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HcIdentityRole>().ToTable("HcIdentityRole");
            modelBuilder.Entity<HcIdentityRole>().ToTable("HcIdentityUser");

            base.OnModelCreating(modelBuilder);
        }
    }
}
